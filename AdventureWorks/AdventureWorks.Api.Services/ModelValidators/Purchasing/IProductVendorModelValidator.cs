using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductVendorRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductVendorRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductVendorRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3c68e6258546352a1f4abefb5583d8f0</Hash>
</Codenesium>*/