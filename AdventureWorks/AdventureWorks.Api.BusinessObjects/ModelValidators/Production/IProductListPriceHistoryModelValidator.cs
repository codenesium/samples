using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductListPriceHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductListPriceHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductListPriceHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>226f952891f575b7fd9fa13952b0f213</Hash>
</Codenesium>*/