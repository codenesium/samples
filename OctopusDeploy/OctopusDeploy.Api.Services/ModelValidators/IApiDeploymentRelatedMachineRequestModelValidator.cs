using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiDeploymentRelatedMachineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeploymentRelatedMachineRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeploymentRelatedMachineRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>84a81cb74b7d71d87ea8caa018ee003c</Hash>
</Codenesium>*/