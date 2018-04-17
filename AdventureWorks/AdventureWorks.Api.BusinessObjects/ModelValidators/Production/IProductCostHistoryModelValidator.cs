using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductCostHistoryModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductCostHistoryModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductCostHistoryModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3ba42f9d425a71daed7a3409fc66251c</Hash>
</Codenesium>*/