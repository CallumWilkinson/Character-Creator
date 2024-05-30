using Character_Creator.Models;
using Character_Creator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Character_Creator.Pages
{
    public class EditCharacterModel : PageModel
    {
        private readonly DataService _dataBase;

        public Character Character { get; set; } = new Character();


        public EditCharacterModel(DataService dataBase)
        {
            _dataBase = dataBase;
        }
        public void OnGet(int id)
        {
            Character currentCharacter = _dataBase.GetCharacterByID(id);
            Character = currentCharacter;
        }

        public void OnPost(int id) 
        {
        }
    }
}
