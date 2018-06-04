using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>c0a114222b743911df0e88baae6bba14</Hash>
</Codenesium>*/