namespace Abby.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        void Save();
    }
}
