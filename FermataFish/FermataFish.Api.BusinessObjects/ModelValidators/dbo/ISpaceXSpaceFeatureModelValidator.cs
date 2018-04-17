using System;
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
    <Hash>d25103a65945d5e5995c1007f09d4e0b</Hash>
</Codenesium>*/