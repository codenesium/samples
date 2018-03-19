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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>c3ea09860521f3095317b0c2b24d4314</Hash>
</Codenesium>*/