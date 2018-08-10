using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiSpaceFeatureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5f0432b2904b33f5aa07d254f3adc5f7</Hash>
</Codenesium>*/