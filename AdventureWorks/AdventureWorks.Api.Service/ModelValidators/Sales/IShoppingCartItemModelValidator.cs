using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IShoppingCartItemModelValidator
	{
		ValidationResult Validate(ShoppingCartItemModel entity);

		Task<ValidationResult> ValidateAsync(ShoppingCartItemModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>f0a88c5e350014eb802a83f7a93e46c5</Hash>
</Codenesium>*/