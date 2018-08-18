using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiEventRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiEventRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>cb80324b5d8c0d43075e5d62ace30768</Hash>
</Codenesium>*/