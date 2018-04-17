using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICurrencyRateModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(CurrencyRateModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, CurrencyRateModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2013f72492b17f3d3686c36f8c0ece9e</Hash>
</Codenesium>*/