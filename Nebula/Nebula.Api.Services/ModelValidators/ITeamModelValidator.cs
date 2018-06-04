using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
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
    <Hash>ffb3cf0c5af4d89f407835536e88b5d3</Hash>
</Codenesium>*/