using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiReleaseRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiReleaseRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiReleaseRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>fa75d9007a7ba5a5f75d5ee9df6634a7</Hash>
</Codenesium>*/