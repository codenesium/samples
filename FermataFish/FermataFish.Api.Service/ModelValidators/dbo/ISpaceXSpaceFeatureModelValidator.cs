using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface ISpaceXSpaceFeatureModelValidator
	{
		ValidationResult Validate(SpaceXSpaceFeatureModel entity);

		Task<ValidationResult> ValidateAsync(SpaceXSpaceFeatureModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>f6868acb37f2e254dc85862cf070b964</Hash>
</Codenesium>*/