using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiUserRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUserRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiUserRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>d009ec6d3588d0a6b342c8eb4f95f4be</Hash>
</Codenesium>*/