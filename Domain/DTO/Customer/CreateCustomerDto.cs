using System.ComponentModel.DataAnnotations;

namespace Domain.DTO.Customer
{
    public class CreateCustomerDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    }
}