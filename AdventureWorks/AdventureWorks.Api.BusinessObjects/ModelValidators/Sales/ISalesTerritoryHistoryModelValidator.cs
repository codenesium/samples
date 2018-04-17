using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesTerritoryHistoryModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SalesTerritoryHistoryModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SalesTerritoryHistoryModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9d7c38051e9f8809fa6aa9169d4f40cc</Hash>
</Codenesium>*/