using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiShoppingCartItemRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShoppingCartItemRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShoppingCartItemRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0a6b7877cabf85390dd220d49ba549be</Hash>
</Codenesium>*/