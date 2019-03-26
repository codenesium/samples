using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesTerritoryServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c9154304033749a2262e87ab7a62aef8</Hash>
</Codenesium>*/