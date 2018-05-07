using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesTerritoryHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SalesTerritoryHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SalesTerritoryHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f17aaeefdbc1fc397355822eeadf1e44</Hash>
</Codenesium>*/