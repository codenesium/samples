using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiSpaceFeatureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>21222b820f925ac268c9ce0f18d5fcb8</Hash>
</Codenesium>*/