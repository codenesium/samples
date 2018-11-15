using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiSaleServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1dea09dc46ffec289ebad9b974d11ad4</Hash>
</Codenesium>*/