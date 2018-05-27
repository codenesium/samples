using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiVendorRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVendorRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVendorRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fbd1da0d514df8c14cc3393df132f629</Hash>
</Codenesium>*/