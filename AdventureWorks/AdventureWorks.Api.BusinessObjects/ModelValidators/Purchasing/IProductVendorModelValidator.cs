using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductVendorModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductVendorModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductVendorModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f5b88eeb374eabcc3b107fa9853d0a53</Hash>
</Codenesium>*/