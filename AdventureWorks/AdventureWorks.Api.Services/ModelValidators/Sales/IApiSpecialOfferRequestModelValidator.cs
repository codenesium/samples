using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSpecialOfferRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>13c790dc13b986d6d94cd7da25e485e9</Hash>
</Codenesium>*/