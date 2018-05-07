using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductCategoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductCategoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductCategoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f03ea399f7d855a513986fe6f2c6407f</Hash>
</Codenesium>*/