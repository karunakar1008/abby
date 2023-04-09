using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
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
            if (ModelState.IsValid)
            {
                var categoryFromDb = _unitOfWork.CategoryRepository.GetFirstOrDefault(c => c.Id == Category.Id);
                if (categoryFromDb != null)
                {
                    _unitOfWork.CategoryRepository.Remove(categoryFromDb);
                    _unitOfWork.CategoryRepository.Save();
                    TempData["success"] = "Category deleted successfully!";
                }
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
