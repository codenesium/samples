using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiServerTaskRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiServerTaskRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiServerTaskRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>67ecca59939a74db6ca0caf146c4a977</Hash>
</Codenesium>*/