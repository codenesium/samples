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
    <Hash>3e7fc2251554c82b752e838112cf6ac0</Hash>
</Codenesium>*/