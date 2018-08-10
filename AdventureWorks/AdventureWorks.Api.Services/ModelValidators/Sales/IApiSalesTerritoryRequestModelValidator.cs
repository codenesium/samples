using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesTerritoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2b7bdd7fa2aa09132f4e49719e6dae0f</Hash>
</Codenesium>*/