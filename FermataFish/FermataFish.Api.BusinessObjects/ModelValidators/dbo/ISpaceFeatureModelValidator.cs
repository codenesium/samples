using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ISpaceFeatureModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SpaceFeatureModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SpaceFeatureModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6f6a101fd61c0c3415eb53816a167bab</Hash>
</Codenesium>*/