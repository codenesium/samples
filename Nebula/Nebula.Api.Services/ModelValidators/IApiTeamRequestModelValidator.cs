using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public interface IApiTeamRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeamRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeamRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8fb3c51ad4ceb6b3abcd5c61f40f78e9</Hash>
</Codenesium>*/