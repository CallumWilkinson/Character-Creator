using System.ComponentModel.DataAnnotations;

namespace Character_Creator.Models
{
    public class Character
    {
        public int CharacterId { get; set; }

        [MaxLength(20)]
        public string Name { get; set; } = "";

        [MaxLength(20)]
        public string Race { get; set; } = "";

        [MaxLength(20)]
        public string Class { get; set; } = "";

        public int? Level { get; set; }
    }
}
