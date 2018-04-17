using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductInventoryModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductInventoryModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductInventoryModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4774369304bca4cf3c7e4349b77b878c</Hash>
</Codenesium>*/