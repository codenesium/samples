using System;
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
    <Hash>7d455ca1a3984b97ecaaecb6dd3633a0</Hash>
</Codenesium>*/