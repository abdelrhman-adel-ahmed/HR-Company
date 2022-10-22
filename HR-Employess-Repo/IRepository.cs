namespace HR_Employess_Repo
{
    public interface IRepository<T>
    {
        Task<ICollection<T>> GetAll();
        T Get(int id);
        Task InsertAsync(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Remove(T entity);
        Task SaveChanges();
    }
}
