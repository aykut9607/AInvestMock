

using FinanceProfile.Api.Core.DataAccess.EntityFramework;
using FinanceProfile.Api.Domain.Entities;
using FinanceProfile.Api.Infrastructure.Abstract;

namespace FinanceProfile.Api.Infrastructure.EntityFramework;

public class EfFinancialProfileDal:EfEntityRepositoryBase<FinancialProfile,FinanceDbContext>,IFinancialProfileDal
{
    public EfFinancialProfileDal(FinanceDbContext context) : base(context)
    {
    }
}