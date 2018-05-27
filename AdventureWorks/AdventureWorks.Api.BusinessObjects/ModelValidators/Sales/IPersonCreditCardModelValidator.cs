using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPersonCreditCardRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonCreditCardRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonCreditCardRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>604877960084ca8d8b1cf7c0ea1a6162</Hash>
</Codenesium>*/