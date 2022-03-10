using MotoApp.Entities;

namespace MotoApp.Repositories
{
    internal interface IReadRepository<out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
