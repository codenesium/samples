using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface ISpaceModelValidator
	{
		ValidationResult Validate(SpaceModel entity);

		Task<ValidationResult> ValidateAsync(SpaceModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>8a97b5f9421659a7bb9f4903417f7f17</Hash>
</Codenesium>*/