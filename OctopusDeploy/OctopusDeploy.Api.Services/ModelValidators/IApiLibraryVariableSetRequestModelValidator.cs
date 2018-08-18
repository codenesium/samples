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
    <Hash>c704b7bd4686c8f474a5ea01167875c1</Hash>
</Codenesium>*/