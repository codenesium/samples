using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductListPriceHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductListPriceHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductListPriceHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9f8f8d32511eb569c3fb8caaac1ba248</Hash>
</Codenesium>*/