using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISpecialOfferProductModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SpecialOfferProductModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SpecialOfferProductModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a3ff9c5f5016487d7a71308c2a6a66b7</Hash>
</Codenesium>*/