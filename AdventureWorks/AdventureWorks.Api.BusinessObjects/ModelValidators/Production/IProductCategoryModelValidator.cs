using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductCategoryModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductCategoryModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductCategoryModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>54b362af33b65f15a7d3a87df4f61c80</Hash>
</Codenesium>*/