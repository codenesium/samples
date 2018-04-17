using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductSubcategoryModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductSubcategoryModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductSubcategoryModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>311b98e70ef75c395990197136da7795</Hash>
</Codenesium>*/