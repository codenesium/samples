using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiSalesTerritoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4438e6b6cfc42725b4711da8752adaff</Hash>
</Codenesium>*/