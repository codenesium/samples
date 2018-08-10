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
    <Hash>4cc652ad9b9484e2f6c42b122ae557c0</Hash>
</Codenesium>*/