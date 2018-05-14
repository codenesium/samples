using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiShoppingCartItemModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShoppingCartItemModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShoppingCartItemModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cebadecda6b036575ada00861adbbe01</Hash>
</Codenesium>*/