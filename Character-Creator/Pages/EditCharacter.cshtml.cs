using Character_Creator.Models;
using Character_Creator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Character_Creator.Pages
{
    public class EditCharacterModel : PageModel
    {
        private readonly DataService _dataBase;

        [BindProperty]
        public Character Character { get; set; } = new Character();


        public EditCharacterModel(DataService dataBase)
        {
            _dataBase = dataBase;
        }
        public void OnGet(int id)
        {
            Character originalCharacter = _dataBase.GetCharacterByID(id);
            Character = originalCharacter;
        }

        public string errorMessage = "";

        public void OnPost(int id) 
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all required fields";
                return;
            }

            Character updatedCharacter = new Character()
            {
                CharacterId = id,
                Name = Character.Name,
                Race = Character.Race,
                Class = Character.Class,
                Level = Character.Level,
            };

            _dataBase.UpdateCharacter(updatedCharacter);

            TempData["SuccessMessage"] = "Character created successfully! Press back to return to the Character List";


        }
    }
}
