using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface ISpaceFeatureModelValidator
	{
		ValidationResult Validate(SpaceFeatureModel entity);

		Task<ValidationResult> ValidateAsync(SpaceFeatureModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>48a680538da134956471a5f7830040e9</Hash>
</Codenesium>*/