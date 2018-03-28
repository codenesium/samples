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
    <Hash>9573c25d1551f6499bf24a540bbd9466</Hash>
</Codenesium>*/