using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Character_Creator.Models;

namespace Character_Creator.Pages
{

    //this is a model
    public class IndexModel : PageModel
    {
        public List<Character> Characters { get; set; } = new List<Character>();

        public void OnGet()
        {

        }
    }
}
