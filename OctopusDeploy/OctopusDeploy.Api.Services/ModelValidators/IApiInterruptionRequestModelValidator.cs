using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiInterruptionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiInterruptionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiInterruptionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>dbb9a8c19ddd782583f83ee036d7b95f</Hash>
</Codenesium>*/