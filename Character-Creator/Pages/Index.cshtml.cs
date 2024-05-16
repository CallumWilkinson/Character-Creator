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
            //populate this class' characters list with the 5 default characters in the db
            Character char1 = _dataBase.GetCharacterByID(1);
            Character char2 = _dataBase.GetCharacterByID(2);
            Character char3 = _dataBase.GetCharacterByID(3);
            Character char4 = _dataBase.GetCharacterByID(4);
            Character char5 = _dataBase.GetCharacterByID(5);

            Characters.Add(char1);
            Characters.Add(char2);
            Characters.Add(char3);
            Characters.Add(char4);
            Characters.Add(char5);

        }
    }
}
