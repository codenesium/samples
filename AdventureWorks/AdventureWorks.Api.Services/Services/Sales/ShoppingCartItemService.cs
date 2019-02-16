using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ShoppingCartItemService : AbstractShoppingCartItemService, IShoppingCartItemService
	{
		public ShoppingCartItemService(
			ILogger<IShoppingCartItemRepository> logger,
			IMediator mediator,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IApiShoppingCartItemServerRequestModelValidator shoppingCartItemModelValidator,
			IDALShoppingCartItemMapper dalShoppingCartItemMapper)
			: base(logger,
			       mediator,
			       shoppingCartItemRepository,
			       shoppingCartItemModelValidator,
			       dalShoppingCartItemMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>767398a4a2ceb2b9a00be7908e20d596</Hash>
</Codenesium>*/