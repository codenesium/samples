using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISpecialOfferProductModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SpecialOfferProductModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SpecialOfferProductModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f8136c30aeef3ba9f30ec6779f7addb0</Hash>
</Codenesium>*/