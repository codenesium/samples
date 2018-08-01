using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiServerTaskRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiServerTaskRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiServerTaskRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>ffd7c9ddf7e8b33b2d81917aad112fed</Hash>
</Codenesium>*/