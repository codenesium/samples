using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSpecialOfferModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>84b872bc4ac4129baa5e9ed9522b63ba</Hash>
</Codenesium>*/