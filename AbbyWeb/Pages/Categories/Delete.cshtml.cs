using Abby.DataAccess;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryRepository _db;
        public DeleteModel(ICategoryRepository db)
        {
            _db = db;
        }
        [BindProperty]
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _db.GetFirstOrDefault(c => c.Id == id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var categoryFromDb = _db.GetFirstOrDefault(c => c.Id == Category.Id);
                if (categoryFromDb != null)
                {
                    _db.Remove(categoryFromDb);
                    _db.Save();
                    TempData["success"] = "Category deleted successfully!";
                }
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
