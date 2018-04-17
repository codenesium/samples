using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>92f94c56e18978e18a4cc4fbbf9ff648</Hash>
</Codenesium>*/