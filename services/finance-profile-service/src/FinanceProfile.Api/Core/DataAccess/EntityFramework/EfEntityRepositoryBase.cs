using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using FinanceProfile.Api.Core.Entities;
using FinanceProfile.Api.Core.DataAccess;
     

namespace FinanceProfile.Api.Core.DataAccess.EntityFramework;
public class EfEntityRepositoryBase<TEntity,TContext>: IEntityRepository<TEntity> 
where TEntity: class,IEntity,new()
where TContext : DbContext
{
    protected readonly TContext _context;
    //protected because this class will be inherited by other classes.(EfFinancialProfileDal ).so we want to make it accessible to the derived classes.
    //but others classes that are not derived from this class should not be able to access it. so we use protected.
    //readonly it is like final in Java. it means that the value of this variable cannot be changed after it is initialized.
    // but in .net  we can only assign a value to it in the constructor.

    public EfEntityRepositoryBase(TContext context)
    {
        _context = context;
    }


      public async Task AddAsync(TEntity entity)
      //async means that this method will be executed asynchronously. 
    {
        var addedEntity  = _context.Entry(entity);
        //there is change tracker in entity framework. it keeps track of the changes made to the entities. 
        // so when we call _context.Entry(entity), it returns an object that represents the entity and its state in the change tracker.(Objects to be added, updated, and deleted ...)
        //so we added addedEntity in this waiting list.

        addedEntity.State = EntityState.Added;
        //and for addedEntity ve say this entity is in added state. so when we call SaveChangesAsync(), it will be added to the database.

        await _context.SaveChangesAsync();
        //await means Wait here for the background process to complete without locking the main thread or UI(just like in JS).
        // EF Core scans all marked objects in the waiting list (those with State == Added), for each of them, 
        // then it generates an INSERT statement and executes it against the database.
    }


    public async Task DeleteAsync(TEntity entity)
    {
        var deletedEntity =_context.Entry(entity);
        deletedEntity.State=EntityState.Deleted;
        await _context.SaveChangesAsync();
    } 

    public async Task UpdateAsync(TEntity entity)
    {
        var updatedEntity=_context.Entry(entity);
        updatedEntity.State=EntityState.Modified;
        await _context.SaveChangesAsync();
    }

     public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _context.Set<TEntity>().SingleOrDefaultAsync(filter);
       //getting user by ID. It expects exactly one record matching the filter; returns null if none exists
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        return filter == null
            ? await _context.Set<TEntity>().ToListAsync()
            //if no filter,then get all the data from the database and return it as a list.

            : await _context.Set<TEntity>().Where(filter).ToListAsync();
            //if filter is provided,then get the data from the database that matches the filter and return it as a list.
    }




}

