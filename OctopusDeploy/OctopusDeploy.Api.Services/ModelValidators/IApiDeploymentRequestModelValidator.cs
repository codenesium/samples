using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiDeploymentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeploymentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>ab9b09e721b0713ff629f0024d8de6e0</Hash>
</Codenesium>*/