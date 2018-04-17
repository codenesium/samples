using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesTerritoryModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SalesTerritoryModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SalesTerritoryModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>533283fba64ed9acc7159fa9f3f45ac9</Hash>
</Codenesium>*/