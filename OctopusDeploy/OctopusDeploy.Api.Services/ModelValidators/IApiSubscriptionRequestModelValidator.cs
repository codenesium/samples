using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiSubscriptionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSubscriptionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiSubscriptionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>835561b21aa748f01e4f27148b5e0d0c</Hash>
</Codenesium>*/