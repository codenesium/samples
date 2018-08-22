using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiIllustrationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiIllustrationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiIllustrationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>374e109971d53148469355be8fbb2d81</Hash>
</Codenesium>*/