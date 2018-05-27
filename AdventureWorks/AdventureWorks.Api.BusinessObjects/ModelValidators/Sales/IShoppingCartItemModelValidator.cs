using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiShoppingCartItemRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShoppingCartItemRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShoppingCartItemRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0c1b2e07799f85e669c34830a2d2067e</Hash>
</Codenesium>*/