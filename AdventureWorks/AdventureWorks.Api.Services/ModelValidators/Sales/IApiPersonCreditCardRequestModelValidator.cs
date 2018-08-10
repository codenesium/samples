using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPersonCreditCardRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonCreditCardRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonCreditCardRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>67250f2913bf878684b2b57085e0ced7</Hash>
</Codenesium>*/