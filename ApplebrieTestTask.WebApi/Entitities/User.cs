using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApplebrieTestTask.WebApi.Entitities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]

        public string LastName { get; set; }

        [Required]
        public Category Category { get; set; }


    }
}
