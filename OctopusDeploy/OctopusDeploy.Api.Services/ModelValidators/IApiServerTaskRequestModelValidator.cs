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
    <Hash>2dcc4da529b5a653e23cadc2839365f9</Hash>
</Codenesium>*/