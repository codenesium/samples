using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiCurrencyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCurrencyRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>a2e6d32e4abbb5d98197e28dc1d579ce</Hash>
</Codenesium>*/