using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ISpaceFeatureModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SpaceFeatureModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SpaceFeatureModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9e7430796c1b4d89af30c069d0d226d5</Hash>
</Codenesium>*/