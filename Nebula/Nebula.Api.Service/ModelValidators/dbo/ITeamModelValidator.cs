using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Service
{
	public interface ITeamModelValidator
	{
		ValidationResult Validate(TeamModel entity);

		Task<ValidationResult> ValidateAsync(TeamModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>67aad031b6f10b36765ef2de550122b5</Hash>
</Codenesium>*/