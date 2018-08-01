using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiProjectTriggerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProjectTriggerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectTriggerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>9c5a083fe2ff77da9ce49f82bd9aabce</Hash>
</Codenesium>*/