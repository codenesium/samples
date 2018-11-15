using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ShoppingCartItemService : AbstractShoppingCartItemService, IShoppingCartItemService
	{
		public ShoppingCartItemService(
			ILogger<IShoppingCartItemRepository> logger,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IApiShoppingCartItemServerRequestModelValidator shoppingCartItemModelValidator,
			IBOLShoppingCartItemMapper bolShoppingCartItemMapper,
			IDALShoppingCartItemMapper dalShoppingCartItemMapper)
			: base(logger,
			       shoppingCartItemRepository,
			       shoppingCartItemModelValidator,
			       bolShoppingCartItemMapper,
			       dalShoppingCartItemMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5b4beeaaabb8fc83975a3690b4eb5823</Hash>
</Codenesium>*/