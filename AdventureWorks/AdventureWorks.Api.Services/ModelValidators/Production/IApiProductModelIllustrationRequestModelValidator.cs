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
    <Hash>dd5055d501b874c5fb69d24e50e8bae7</Hash>
</Codenesium>*/