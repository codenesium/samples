using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ISpaceXSpaceFeatureModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SpaceXSpaceFeatureModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SpaceXSpaceFeatureModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dfe855ff6097e8cd2c600d9cf32f0fb2</Hash>
</Codenesium>*/