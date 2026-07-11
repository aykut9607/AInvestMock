using FinancialIQ.Api.Core.Utilities.Results;
using IResult = FinancialIQ.Api.Core.Utilities.Results.IResult;
using FinancialIQ.Api.Domain.Entities;

namespace FinancialIQ.Api.Application.Abstract;

public interface IFinancialIqService
{
    Task<IDataResult<List<FinancialIqResult>>> GetAllAsync();
    Task<IResult>AddAsync(FinancialIqResult financialIqResult);
}