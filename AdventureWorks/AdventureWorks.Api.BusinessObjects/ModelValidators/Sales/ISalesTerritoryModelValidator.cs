using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesTerritoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SalesTerritoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SalesTerritoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a138eb2fc901c0fcefc68a34ccc948f2</Hash>
</Codenesium>*/