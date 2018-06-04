using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiSalesTaxRateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTaxRateRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTaxRateRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>58207ac68dae6736f940627d52561a3f</Hash>
</Codenesium>*/