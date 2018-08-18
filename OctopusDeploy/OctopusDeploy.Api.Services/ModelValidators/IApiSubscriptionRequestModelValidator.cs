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
    <Hash>28d72c384596f3414f96ebd1b8c63572</Hash>
</Codenesium>*/