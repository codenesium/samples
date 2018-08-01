using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiLifecycleRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLifecycleRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiLifecycleRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>88edc9aa1414c4ffcc6094e36dd9cb47</Hash>
</Codenesium>*/