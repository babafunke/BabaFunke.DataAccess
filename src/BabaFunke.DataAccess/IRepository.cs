using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabaFunke.DataAccess
{
    public interface IRepository<T> where T:IPrimaryKey
    {
        Task<IEnumerable<T>> GetAllItems();
        Task<T> GetItemById(int id);
        Task<T> CreateItem(T item);
        Task<T> EditItem(T item);
        Task<bool> DeleteItem(int id);
        Task<bool> ArchiveItem(int id);
    }
}   
