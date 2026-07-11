using FinancialIQ.Api.Core.DataAccess.EntityFramework;
using FinancialIQ.Api.Domain.Entities;
using FinancialIQ.Api.Infrastructure.Abstract;

namespace FinancialIQ.Api.Infrastructure.EntityFramework;

public class EfFinancialIqResultDal:EfEntityRepositoryBase<FinancialIqResult,FinancialIqDbContext>,IFinancialIqResultDal
{
    public EfFinancialIqResultDal(FinancialIqDbContext  context) : base(context)
    {
    }
}