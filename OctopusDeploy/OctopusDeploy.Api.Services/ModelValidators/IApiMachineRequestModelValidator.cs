using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiMachineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiMachineRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>a84bd9b127cc9e671af0f1df395b42ef</Hash>
</Codenesium>*/