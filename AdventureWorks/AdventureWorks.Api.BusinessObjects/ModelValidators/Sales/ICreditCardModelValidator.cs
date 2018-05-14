using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCreditCardModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCreditCardModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7512775d36632000d1d25ac8529930e4</Hash>
</Codenesium>*/