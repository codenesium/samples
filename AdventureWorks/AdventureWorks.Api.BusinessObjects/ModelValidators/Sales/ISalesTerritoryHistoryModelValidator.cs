using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesTerritoryHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ccd14593abc8330b39479f24a183cb20</Hash>
</Codenesium>*/