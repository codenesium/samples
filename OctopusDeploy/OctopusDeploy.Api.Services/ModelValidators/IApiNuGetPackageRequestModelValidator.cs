using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiNuGetPackageRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiNuGetPackageRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiNuGetPackageRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>246ab51ebf3e46d5d042b4d7e7b623db</Hash>
</Codenesium>*/