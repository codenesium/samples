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
    <Hash>cfd95df1413544c874f976d29a6a6839</Hash>
</Codenesium>*/