using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>7d7cd3f6cacf3645d713df0699aca5f3</Hash>
</Codenesium>*/