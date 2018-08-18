using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>899b283921afb188ea4676d9f1a54bcb</Hash>
</Codenesium>*/