using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiErrorLogRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiErrorLogRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a3b89ee512cc18cf4231872da888a954</Hash>
</Codenesium>*/