using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductListPriceHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductListPriceHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductListPriceHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b326eec342fccfb7997396962cf63e5b</Hash>
</Codenesium>*/