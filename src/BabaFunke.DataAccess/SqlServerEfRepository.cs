using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabaFunke.DataAccess
{
    public abstract class SqlServerEfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IPrimaryKey
    {

        /// <summary>
        /// Gets all the items (all rows) in the table entity
        /// </summary>
        /// <returns>Returns a list of all items</returns>
        public virtual Task<IEnumerable<TEntity>> GetAllItems()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a single item which corresponds to a row in the table entity
        /// </summary>
        /// <param name="id">Id is the primary key of the item</param>
        /// <returns>Return a single item defined by the entity</returns>
        public virtual Task<TEntity> GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new item in the table
        /// </summary>
        /// <param name="item">The item to create</param>
        /// <returns></returns>
        public virtual Task<TEntity> CreateItem(TEntity item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a single item in the table
        /// </summary>
        /// <param name="item">The item to update</param>
        /// <returns></returns>
        public virtual Task<TEntity> EditItem(TEntity item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a single item from the table
        /// </summary>
        /// <param name="id">The Id of the item</param>
        /// <returns></returns>
        public virtual Task<bool> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Disables a single item in a table as an alternative to deleting the item
        /// </summary>
        /// <param name="id">The Id of the item</param>
        /// <returns></returns>
        public virtual Task<bool> ArchiveItem(int id)
        {
            throw new NotImplementedException();
        }
    }
}
