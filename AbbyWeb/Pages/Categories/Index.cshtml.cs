using Abby.DataAccess;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository _db;
        public IndexModel(ICategoryRepository db)
        {
            _db = db;
        }
        public IEnumerable<Category> Categories { get; set; }

        public void OnGet()
        {
            Categories = _db.GetAll();
        }
    }
}
