using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiSubscriptionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSubscriptionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiSubscriptionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>83d007e0b0c71834ef5e97082bee5c38</Hash>
</Codenesium>*/