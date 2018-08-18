using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiSaleRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>96cdc01d9f811bece763848096a0efac</Hash>
</Codenesium>*/