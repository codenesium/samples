using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiOctopusServerNodeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOctopusServerNodeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiOctopusServerNodeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>df06acc8d86055bbd19bc840dcec360d</Hash>
</Codenesium>*/