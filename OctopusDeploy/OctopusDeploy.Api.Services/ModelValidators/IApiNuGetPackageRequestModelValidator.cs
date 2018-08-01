using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiNuGetPackageRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiNuGetPackageRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiNuGetPackageRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>c9143864f4845d22d4e8106cacf9c6b3</Hash>
</Codenesium>*/