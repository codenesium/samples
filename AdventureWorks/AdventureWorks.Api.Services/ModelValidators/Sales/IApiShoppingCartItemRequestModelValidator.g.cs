using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiShoppingCartItemRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShoppingCartItemRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShoppingCartItemRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4ba2faa3f72c01503ddf575002d71d2b</Hash>
</Codenesium>*/