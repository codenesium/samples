using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiTeamRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeamRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeamRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>59daff4af32d4b699a4f4ddc4244ac3a</Hash>
</Codenesium>*/