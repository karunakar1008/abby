using Abby.DataAccess;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category=_db.Categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name and display order should be not the same.");
            }
            if (ModelState.IsValid)
            {
                 _db.Categories.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully!";
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
