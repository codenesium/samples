using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISpecialOfferModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SpecialOfferModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SpecialOfferModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0326cdb0eba3797e8cd9a5a8d0b198e6</Hash>
</Codenesium>*/