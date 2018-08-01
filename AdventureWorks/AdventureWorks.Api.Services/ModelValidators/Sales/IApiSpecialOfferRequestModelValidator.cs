using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiSpecialOfferRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0cc8c3c194f270cc5698da4d8cf08d37</Hash>
</Codenesium>*/