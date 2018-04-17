using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IShoppingCartItemModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ShoppingCartItemModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ShoppingCartItemModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>70a69db5beafdf4d44f957ce20f6123a</Hash>
</Codenesium>*/