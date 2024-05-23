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
            Character newCharacter = new Character()
            {
                Name = Character.Name,
                Race = Character.Race,
                Class = Character.Class,
                Level = Character.Level,
            };

            _dataBase.AddCharacter(newCharacter);


            //clear the form
            Character.Name = "";
            Character.Race = "";
            Character.Class = "";
            Character.Level = 0;

            ModelState.Clear();

            Response.Redirect("Index");

        }
    }
}
