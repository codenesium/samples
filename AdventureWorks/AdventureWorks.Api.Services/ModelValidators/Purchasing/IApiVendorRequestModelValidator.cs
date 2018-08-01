using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiVendorRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVendorRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVendorRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3e42bc40b50658ec3c5a38c9d6201c93</Hash>
</Codenesium>*/