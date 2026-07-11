using FinanceProfile.Api.Core.Utilities.Results;
using IResult = FinanceProfile.Api.Core.Utilities.Results.IResult;
using FinanceProfile.Api.Domain.Entities;

namespace FinanceProfile.Api.Application.Abstract;

public interface IFinancialProfileService
{
    Task<IDataResult<List<FinancialProfile>>> GetAllAsync();
    Task<IResult>AddAsync(FinancialProfile financialProfile);
}