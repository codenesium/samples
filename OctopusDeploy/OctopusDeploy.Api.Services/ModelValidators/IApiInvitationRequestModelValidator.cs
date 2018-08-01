using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiInvitationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiInvitationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiInvitationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>267208e84e35db50170c7ba575f13b47</Hash>
</Codenesium>*/