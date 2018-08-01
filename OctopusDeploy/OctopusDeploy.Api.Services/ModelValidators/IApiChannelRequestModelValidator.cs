using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiChannelRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChannelRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiChannelRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>514e17461a7e5fcbdce10b64a489e7b4</Hash>
</Codenesium>*/