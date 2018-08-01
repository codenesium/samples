using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiIllustrationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiIllustrationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiIllustrationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a5550b92486ae92680d9cb5bde864ff2</Hash>
</Codenesium>*/