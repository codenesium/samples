using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiSalesTerritoryHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryHistoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryHistoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>79ee8ea86b9e8544f445eeacfd2714fb</Hash>
</Codenesium>*/