using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>461adfe48c3cc87972381ef49437bf2c</Hash>
</Codenesium>*/