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
    <Hash>c80676f09ee2c84c858b73dba0118a5a</Hash>
</Codenesium>*/