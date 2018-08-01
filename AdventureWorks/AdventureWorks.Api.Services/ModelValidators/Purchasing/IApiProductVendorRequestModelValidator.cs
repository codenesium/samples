using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>2c8c334b2f2d9dd8dee4239b8530e462</Hash>
</Codenesium>*/