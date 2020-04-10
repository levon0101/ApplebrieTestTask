using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApplebrieTestTask.WebApi.Entitities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]

        public string Name { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}