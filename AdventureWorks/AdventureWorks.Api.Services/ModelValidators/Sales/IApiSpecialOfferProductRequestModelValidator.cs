using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSpecialOfferProductRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferProductRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferProductRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>846a78d1df32e9bf2f1a44074a6c404e</Hash>
</Codenesium>*/