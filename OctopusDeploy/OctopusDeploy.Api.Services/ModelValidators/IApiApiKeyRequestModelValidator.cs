using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiApiKeyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiApiKeyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiApiKeyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>2b6d6df760670badfc81f7d2c488d68f</Hash>
</Codenesium>*/