using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Character_Creator.Models;
using Character_Creator.Services;

namespace Character_Creator.Pages
{

    //this is a model
    public class IndexModel : PageModel
    {
        private readonly DataService _dataBase;
        public List<Character> Characters { get; set; } = new List<Character>();

        public IndexModel(DataService dataBase)
        {
            _dataBase = dataBase;
        }

        public void OnGet()
        {
            Characters = _dataBase.GetAllCharacters();
        }

        public void OnPost()
        {
            //int searchId = 1;
            //Character foundCharacter = Characters.Find(character => character.CharacterId == searchId);
            //int foundCharacterID = foundCharacter.CharacterId;


            //_dataBase.DeleteCharacter();
        }

        public IActionResult OnPostDelete(int characterID)
        {
            _dataBase.DeleteCharacter(characterID);
            return RedirectToPage();
        }
    }
}
