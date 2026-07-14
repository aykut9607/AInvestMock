using System.Linq.Expressions;
using FinanceProfile.Api.Core.Entities;

namespace FinanceProfile.Api.Core.DataAccess;

public interface IEntityRepository<T>where T : class, IEntity, new()
{
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        //it says it is not a must to use filter. it is optional. if you want to get all the data, you can just call GetAllAsync() without any filter.
        //  if you want to get specific data, you can use filter. but as default ,filter is null. so if you don't provide any filter, it will return all the data.
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        //for this ,the data can be null. so we use T? instead of T.
        //  because if the data is not found, it will return null. so we use T? to indicate that the data can be null.

        Task AddAsync(T entity);
        //Task is like a promise in JavaScript(but doesnt return anything,its void). it is a way to handle asynchronous operations- and a way to handle operations that take time to complete
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);




}