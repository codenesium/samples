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
    <Hash>57c769bcbffc16c745b558cee78f4ece</Hash>
</Codenesium>*/