using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IVendorModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(VendorModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, VendorModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dc088f1978f3c4204718f6546ae744e0</Hash>
</Codenesium>*/