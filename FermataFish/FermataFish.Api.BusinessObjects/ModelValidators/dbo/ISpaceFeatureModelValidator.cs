using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiSpaceFeatureModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7c011ffa1a58f90097e8db8f0da33ab8</Hash>
</Codenesium>*/