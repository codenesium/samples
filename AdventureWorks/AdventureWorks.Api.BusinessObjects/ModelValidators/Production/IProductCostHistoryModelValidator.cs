using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductCostHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductCostHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductCostHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>075be9e5d79a081ac439958e7997c2ce</Hash>
</Codenesium>*/