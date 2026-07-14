using FinanceProfile.Api.Domain.Entities;
using FinanceProfile.Api.Core.DataAccess;


namespace FinanceProfile.Api.Infrastructure.Abstract;

public interface IFinancialProfileDal:IEntityRepository<FinancialProfile>
{
    public  Task UpsertAsync(FinancialProfile entity);
}