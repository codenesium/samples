using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IVendorModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(VendorModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, VendorModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c346e585f5050e06645f17b14e2a6d4b</Hash>
</Codenesium>*/