using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiTeamRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeamRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiTeamRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>48ac9f14c5d13159aa83e9e11a83672d</Hash>
</Codenesium>*/