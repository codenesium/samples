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
    <Hash>30e4530362158433448d6323a5fefc5c</Hash>
</Codenesium>*/