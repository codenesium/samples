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
    <Hash>47c23674b9f26f0933177016a5a9f899</Hash>
</Codenesium>*/