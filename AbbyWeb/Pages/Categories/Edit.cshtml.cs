using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _unitOfWork.CategoryRepository.GetFirstOrDefault(c => c.Id == id);
        }

        public IActionResult OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name and display order should be not the same.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(Category);
                _unitOfWork.CategoryRepository.Save();
                TempData["success"] = "Category updated successfully!";
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
