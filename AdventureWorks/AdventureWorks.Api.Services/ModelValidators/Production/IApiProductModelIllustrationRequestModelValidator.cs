using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductModelIllustrationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelIllustrationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelIllustrationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3a5cc8e71e11745f7294044d65f2fa20</Hash>
</Codenesium>*/