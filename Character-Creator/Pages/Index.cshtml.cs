using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Character_Creator.Models;
using Character_Creator.Services;

namespace Character_Creator.Pages
{

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
         
        }

        public IActionResult OnPostDelete(int characterID)
        {
            _dataBase.DeleteCharacter(characterID);
            return RedirectToPage();
        }
    }
}
