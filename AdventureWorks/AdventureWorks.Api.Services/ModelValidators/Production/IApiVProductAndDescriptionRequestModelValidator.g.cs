using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiVProductAndDescriptionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVProductAndDescriptionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiVProductAndDescriptionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>3f3c52afc99e7a3328013ee9d0aac386</Hash>
</Codenesium>*/