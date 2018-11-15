using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiWorkOrderServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4bf223787bc45e2e48e37b4b81ba18e2</Hash>
</Codenesium>*/