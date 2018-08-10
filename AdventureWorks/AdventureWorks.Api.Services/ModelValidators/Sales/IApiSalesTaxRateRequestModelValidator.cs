using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesTaxRateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTaxRateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTaxRateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>233fb8ab1d901b43f49457842045a0a0</Hash>
</Codenesium>*/