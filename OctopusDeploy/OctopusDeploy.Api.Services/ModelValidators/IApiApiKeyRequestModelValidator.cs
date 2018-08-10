using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiApiKeyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiApiKeyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiApiKeyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>6be8b5c4011000b9ddb1238ae3950cfd</Hash>
</Codenesium>*/