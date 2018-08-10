using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiLibraryVariableSetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLibraryVariableSetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiLibraryVariableSetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>2615e18eb7847b7f5cfe1e523e31cffc</Hash>
</Codenesium>*/