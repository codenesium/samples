using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiProjectRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProjectRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>731c0683a0f34ba315394f925309c832</Hash>
</Codenesium>*/