using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ISpaceXSpaceFeatureModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SpaceXSpaceFeatureModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SpaceXSpaceFeatureModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>330ded34ee237d3681ffbba3d2a64d44</Hash>
</Codenesium>*/