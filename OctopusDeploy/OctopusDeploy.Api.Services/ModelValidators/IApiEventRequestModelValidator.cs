using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiEventRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiEventRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>da68121d705866ac808156e0a0359742</Hash>
</Codenesium>*/