using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiProjectGroupRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProjectGroupRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectGroupRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>f153a6089a3fad7f57427ccaf57ffb3b</Hash>
</Codenesium>*/