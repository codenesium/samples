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
    <Hash>c31ca0ed53db55aeef0e42f140f62f76</Hash>
</Codenesium>*/