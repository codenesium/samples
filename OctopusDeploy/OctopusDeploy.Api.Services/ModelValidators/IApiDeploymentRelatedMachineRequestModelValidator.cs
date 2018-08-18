using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiDeploymentRelatedMachineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeploymentRelatedMachineRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeploymentRelatedMachineRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>78f46f1b00996fa7afb12a34bfd6a866</Hash>
</Codenesium>*/