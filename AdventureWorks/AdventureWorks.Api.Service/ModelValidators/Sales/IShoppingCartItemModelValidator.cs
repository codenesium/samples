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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>1109f28f8424524a42bc875840fa54ac</Hash>
</Codenesium>*/