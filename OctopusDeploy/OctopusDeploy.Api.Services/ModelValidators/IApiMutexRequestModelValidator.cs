using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiMutexRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMutexRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiMutexRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>e73e932a3122a60c8a08e15612d5aeed</Hash>
</Codenesium>*/