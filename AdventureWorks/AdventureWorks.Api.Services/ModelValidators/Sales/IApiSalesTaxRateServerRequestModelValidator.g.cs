using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesTaxRateServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTaxRateServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTaxRateServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>45d7d80e3047ac184174dba40a681e98</Hash>
</Codenesium>*/