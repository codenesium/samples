using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCreditCardRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCreditCardRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0cb38d0499b00852d7af3c4fad563d59</Hash>
</Codenesium>*/