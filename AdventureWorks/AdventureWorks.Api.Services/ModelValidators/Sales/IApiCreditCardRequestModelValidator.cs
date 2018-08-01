using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiCreditCardRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCreditCardRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3a9349f996035f8fd31703ca17675dbc</Hash>
</Codenesium>*/