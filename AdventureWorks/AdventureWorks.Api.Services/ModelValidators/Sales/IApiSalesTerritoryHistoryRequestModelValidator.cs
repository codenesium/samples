using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesTerritoryHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bfcd982f649c5afe82557e9ac7a407f6</Hash>
</Codenesium>*/