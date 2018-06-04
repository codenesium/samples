using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiAddressTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressTypeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressTypeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>125d8130d6afaf6997b34f51da29ea09</Hash>
</Codenesium>*/