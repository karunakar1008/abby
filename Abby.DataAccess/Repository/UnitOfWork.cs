using Abby.DataAccess.Repository.IRepository;

namespace Abby.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; private set; }
        public readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
