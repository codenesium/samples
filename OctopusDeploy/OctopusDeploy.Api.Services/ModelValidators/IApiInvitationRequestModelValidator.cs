using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiInvitationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiInvitationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiInvitationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>7e82921dbb4a04ec3abbbf51eed0d527</Hash>
</Codenesium>*/