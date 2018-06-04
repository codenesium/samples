using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>fb09ca513df72a1880cca42e065dfafe</Hash>
</Codenesium>*/