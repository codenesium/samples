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
    <Hash>5c53c75752d4436a160fb46715e46936</Hash>
</Codenesium>*/