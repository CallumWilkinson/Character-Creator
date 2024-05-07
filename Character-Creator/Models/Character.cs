using System.ComponentModel.DataAnnotations;

namespace Character_Creator.Models
{
    public class Character
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; } = "";
    }
}
