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
    <Hash>a394d4a4a60ce91ae392d96ba8abc411</Hash>
</Codenesium>*/