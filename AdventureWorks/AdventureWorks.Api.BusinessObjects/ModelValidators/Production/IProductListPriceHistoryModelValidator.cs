using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductListPriceHistoryModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductListPriceHistoryModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductListPriceHistoryModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c38698e5e59b14d377073c51f109bc13</Hash>
</Codenesium>*/