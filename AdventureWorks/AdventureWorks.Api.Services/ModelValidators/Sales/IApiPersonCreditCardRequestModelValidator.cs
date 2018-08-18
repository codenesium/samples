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
    <Hash>418a33f43d4fde2a74ff85eef18a8baf</Hash>
</Codenesium>*/