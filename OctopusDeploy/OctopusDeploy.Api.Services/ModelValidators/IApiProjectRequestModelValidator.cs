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
    <Hash>a68c41af1f966216f27689c7cf165210</Hash>
</Codenesium>*/