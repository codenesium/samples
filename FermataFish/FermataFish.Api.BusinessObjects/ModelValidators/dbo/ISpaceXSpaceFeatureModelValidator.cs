using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiSpaceXSpaceFeatureModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceXSpaceFeatureModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceXSpaceFeatureModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>da6344046e4c3c7f9125d1a2000e2de9</Hash>
</Codenesium>*/