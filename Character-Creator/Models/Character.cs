using System.ComponentModel.DataAnnotations;

namespace Character_Creator.Models
{
    public class Character
    {
        public int CharacterId { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; } = "";

        [Required, MaxLength(20)]
        public string Race { get; set; } = "";

        [Required, MaxLength(20)]
        public string Class { get; set; } = "";

        [Required, Range(1,60)]
        public int Level { get; set; }
    }
}
