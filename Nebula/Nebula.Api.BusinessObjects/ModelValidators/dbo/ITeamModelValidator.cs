using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface ITeamModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(TeamModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, TeamModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a00c40c20528e7ea725dc990de618811</Hash>
</Codenesium>*/