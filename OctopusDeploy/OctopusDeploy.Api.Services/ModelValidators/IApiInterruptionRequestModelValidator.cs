using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiInterruptionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiInterruptionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiInterruptionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>2c477285dde4ef75a551f8ea2c98a231</Hash>
</Codenesium>*/