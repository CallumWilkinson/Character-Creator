using Character_Creator.Models;
using Character_Creator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Character_Creator.Pages
{
    public class CreateCharacterModel : PageModel
    {
        private readonly DataService _dataBase;

        [BindProperty]
        public Character Character { get; set; } = new Character();

        public CreateCharacterModel(DataService dataBase)
        {
            _dataBase = dataBase;
        }
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            //save the new character to the database
            Character character = new Character()
            {
                Name = Character.Name,
                Race = Character.Race,
                Class = Character.Class,
                Level = Character.Level,
            };

            _dataBase.AddCharacter(character);
            








            //i think i need to use [bindpropery] on the character object so that when user enters name ect in the form it automatically maps that to the characer object
           



            //clear the form
        }
    }
}
