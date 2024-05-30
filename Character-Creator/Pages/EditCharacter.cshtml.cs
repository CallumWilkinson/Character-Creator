using Character_Creator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Character_Creator.Pages
{
    public class EditCharacterModel : PageModel
    {
        private readonly DataService _dataBase;


        public EditCharacterModel(DataService dataBase)
        {
            _dataBase = dataBase;
        }
        public void OnGet()
        {
        }
    }
}
