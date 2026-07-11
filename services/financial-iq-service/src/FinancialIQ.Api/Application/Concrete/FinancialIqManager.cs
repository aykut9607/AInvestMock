using FinancialIQ.Api.Application.Abstract;
using FinancialIQ.Api.Application.Constants;
using FinancialIQ.Api.Core.Utilities.Results;
using IResult = FinancialIQ.Api.Core.Utilities.Results.IResult;
using FinancialIQ.Api.Domain.Entities;
using FinancialIQ.Api.Infrastructure.Abstract;

namespace FinancialIQ.Api.Application.Concrete;

public class FinancialIqManager : IFinancialIqService
{
    private readonly IFinancialIqResultDal _financialIqDal;
    public FinancialIqManager(IFinancialIqResultDal financialIqDal)
    {
        _financialIqDal = financialIqDal;
        
    }

 public async Task<IDataResult<List<FinancialIqResult>>> GetAllAsync()
    {
        var results = await _financialIqDal.GetAllAsync();
        return new SuccessDataResult<List<FinancialIqResult>>(results, Messages.FinancialIqResultsListed);
    }
    public async Task<IResult> AddAsync(FinancialIqResult financialIqResult)
    {
        await _financialIqDal.AddAsync(financialIqResult);
        return new SuccessResult(Messages.FinancialIqResultAdded);
    }

   
}