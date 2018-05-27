using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductListPriceHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductListPriceHistoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductListPriceHistoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1021496d5be9bd6b405f076e27cff427</Hash>
</Codenesium>*/