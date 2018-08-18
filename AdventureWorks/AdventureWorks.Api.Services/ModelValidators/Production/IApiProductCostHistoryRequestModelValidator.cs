using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductCostHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductCostHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCostHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>85594afef7636835b6b165a75069e4a6</Hash>
</Codenesium>*/