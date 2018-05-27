using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSpecialOfferRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3117a3663480d844b2c6e7197e8669a4</Hash>
</Codenesium>*/