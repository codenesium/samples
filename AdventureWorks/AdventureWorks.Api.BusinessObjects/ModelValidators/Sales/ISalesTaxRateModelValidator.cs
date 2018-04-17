using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesTaxRateModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SalesTaxRateModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SalesTaxRateModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cf1e27cc496f68af80329b8af583c6bc</Hash>
</Codenesium>*/