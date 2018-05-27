using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesTerritoryHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryHistoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryHistoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2db2e08aef7c04f9e1114d022642e1f5</Hash>
</Codenesium>*/