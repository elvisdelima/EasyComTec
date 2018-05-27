using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Infrastructure.CrossCutting
{
    public sealed class AppMapper
    {
        private static AppMapper _instance;

        private IMapper Mapper { get; set; }

        private static IEnumerable<Profile> ProfilesAdded { get; set; }

        public static AppMapper Instance => _instance ?? (_instance = new AppMapper());

        private AppMapper()
        {
            MapperConfigure();
        }

        public void AddProfiles(IEnumerable<Profile> profiles)
        {
            ProfilesAdded = profiles;
            MapperConfigure();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        private void MapperConfigure()
        {
            var profiles =
                from type in typeof(AppMapper).GetTypeInfo().Assembly.GetTypes()
                where typeof(Profile).IsAssignableFrom(type)
                select (Profile)Activator.CreateInstance(type);

            Mapper = new MapperConfiguration(config =>
            {
                foreach (var profile in profiles)
                    config.AddProfile(profile);

                if (ProfilesAdded == null) return;
                
                foreach (var profile in ProfilesAdded)
                    config.AddProfile(profile);
            
            }).CreateMapper();
        }
    }
}