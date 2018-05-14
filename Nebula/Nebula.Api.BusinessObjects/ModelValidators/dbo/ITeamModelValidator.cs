using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiTeamModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeamModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeamModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ad2689bf462485c38a4fd522de2efebb</Hash>
</Codenesium>*/