using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiDeploymentHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeploymentHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>3bffefb4cca9eb6a95175094b2967bb6</Hash>
</Codenesium>*/