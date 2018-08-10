using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiMutexRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMutexRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiMutexRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>dfde17de7f3123a2078619c0f4fd5490</Hash>
</Codenesium>*/