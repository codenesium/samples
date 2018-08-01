using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiVariableSetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVariableSetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiVariableSetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>2b2ca3899e337d173fd42e4f8611231e</Hash>
</Codenesium>*/