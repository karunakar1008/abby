using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Category Category { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name and display order should be not the same.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(Category);
                _unitOfWork.CategoryRepository.Save();
                TempData["success"] = "Category created successfully!";
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
