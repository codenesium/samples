using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICurrencyRateModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(CurrencyRateModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, CurrencyRateModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>debeec34efdb017620dcff8d9296d9a3</Hash>
</Codenesium>*/