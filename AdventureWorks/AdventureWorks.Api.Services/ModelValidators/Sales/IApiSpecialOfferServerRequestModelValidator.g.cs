using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSpecialOfferServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6616212fe72f1e3c9adbfe44a6ca1e62</Hash>
</Codenesium>*/