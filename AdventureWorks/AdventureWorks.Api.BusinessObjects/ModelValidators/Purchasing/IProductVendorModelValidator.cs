using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductVendorModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductVendorModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductVendorModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7c46d784b26fa45f56ca2f9adb31d970</Hash>
</Codenesium>*/