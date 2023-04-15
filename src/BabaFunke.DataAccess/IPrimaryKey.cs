namespace BabaFunke.DataAccess
{
    public interface IPrimaryKey
    {
        /// <summary>
        /// The primary key of the entity
        /// </summary>
        int Id { get; set; }
    }
}
