using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSpecialOfferProductModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferProductModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferProductModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bf4e6378b7d325dd88d91ca5878ec4d3</Hash>
</Codenesium>*/