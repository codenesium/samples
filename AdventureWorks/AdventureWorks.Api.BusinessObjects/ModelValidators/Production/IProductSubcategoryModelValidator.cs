using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductSubcategoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductSubcategoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductSubcategoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2abccff924d3cfff8e793ee6aa1c49da</Hash>
</Codenesium>*/