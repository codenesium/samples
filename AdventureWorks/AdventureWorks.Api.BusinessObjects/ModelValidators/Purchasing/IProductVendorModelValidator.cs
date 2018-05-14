using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductVendorModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductVendorModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductVendorModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e5b319ed8d52b1e3e26b375a5f9b973f</Hash>
</Codenesium>*/