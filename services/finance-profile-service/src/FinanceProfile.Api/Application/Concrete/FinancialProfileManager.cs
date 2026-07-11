

using FinanceProfile.Api.Application.Abstract;
using FinanceProfile.Api.Application.Constants;
using FinanceProfile.Api.Core.Utilities.Results;
using IResult = FinanceProfile.Api.Core.Utilities.Results.IResult;
using FinanceProfile.Api.Domain.Entities;
using FinanceProfile.Api.Infrastructure.Abstract;

namespace FinanceProfile.Api.Application.Concrete;


public class FinancialProfileManager : IFinancialProfileService
{
    private readonly IFinancialProfileDal _financialProfileDal;
    public FinancialProfileManager(IFinancialProfileDal financialProfileDal)
    {
        _financialProfileDal = financialProfileDal;
        
    }

 public async Task<IDataResult<List<FinancialProfile>>> GetAllAsync()
    {
        var profiles = await _financialProfileDal.GetAllAsync();
        return new SuccessDataResult<List<FinancialProfile>>(profiles, Messages.FinancialProfileListed);
    }
    public async Task<IResult> AddAsync(FinancialProfile financialProfile)
    {
        await _financialProfileDal.AddAsync(financialProfile);
        return new SuccessResult(Messages.FinancialProfileAdded);
    }

   
}