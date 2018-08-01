using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductModelIllustrationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelIllustrationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelIllustrationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>90fdba9525cd850255cea1401bac6ea1</Hash>
</Codenesium>*/