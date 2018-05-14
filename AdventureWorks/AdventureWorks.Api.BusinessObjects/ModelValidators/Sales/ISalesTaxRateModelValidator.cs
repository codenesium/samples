using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesTaxRateModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTaxRateModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTaxRateModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1e621e717b289c7b62fe4dc1991a2991</Hash>
</Codenesium>*/