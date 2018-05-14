using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesTerritoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>024effcb1bee1efadf298711410baa0e</Hash>
</Codenesium>*/