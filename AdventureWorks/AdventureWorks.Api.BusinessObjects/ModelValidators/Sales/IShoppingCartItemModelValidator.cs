using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IShoppingCartItemModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ShoppingCartItemModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ShoppingCartItemModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5530900f59fa34fc881ffd72834cdb9b</Hash>
</Codenesium>*/