using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface ITeamModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(TeamModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, TeamModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>625e429be68eb7f1f85e6be86a60abe3</Hash>
</Codenesium>*/