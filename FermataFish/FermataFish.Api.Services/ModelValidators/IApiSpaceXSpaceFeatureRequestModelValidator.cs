using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiSpaceXSpaceFeatureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceXSpaceFeatureRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceXSpaceFeatureRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3a4cbba10fd4eb215b767d0acc95a230</Hash>
</Codenesium>*/