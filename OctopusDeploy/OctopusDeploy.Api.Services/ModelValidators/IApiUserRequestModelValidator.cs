using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiUserRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUserRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiUserRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>c42737eeee4023f94c2ce393d057c6d5</Hash>
</Codenesium>*/