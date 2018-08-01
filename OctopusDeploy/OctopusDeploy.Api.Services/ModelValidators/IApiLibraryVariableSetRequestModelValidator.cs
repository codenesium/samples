using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiLibraryVariableSetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLibraryVariableSetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiLibraryVariableSetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>c426a413f320258cc975c883fe7a958b</Hash>
</Codenesium>*/