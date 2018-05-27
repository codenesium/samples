using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesTaxRateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTaxRateRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTaxRateRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>281aaac3a66aeb2a368316143605ad8a</Hash>
</Codenesium>*/