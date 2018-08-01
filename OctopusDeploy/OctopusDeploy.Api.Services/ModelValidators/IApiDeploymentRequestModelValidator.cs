using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiDeploymentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeploymentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>5422ce812afc5e545c5c4a345de6aa6c</Hash>
</Codenesium>*/