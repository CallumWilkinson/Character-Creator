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
            //populate this class' characters list with the characters in the db
            //Characters = _dataBase.

        }
    }
}
