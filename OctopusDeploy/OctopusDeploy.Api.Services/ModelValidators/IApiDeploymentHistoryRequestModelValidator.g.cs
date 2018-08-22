using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiDeploymentHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeploymentHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>b4ecca7f5a60facb1ab462f7a1608869</Hash>
</Codenesium>*/