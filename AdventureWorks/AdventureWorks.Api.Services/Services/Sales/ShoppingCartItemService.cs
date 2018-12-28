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
			IBOLShoppingCartItemMapper bolShoppingCartItemMapper,
			IDALShoppingCartItemMapper dalShoppingCartItemMapper)
			: base(logger,
			       mediator,
			       shoppingCartItemRepository,
			       shoppingCartItemModelValidator,
			       bolShoppingCartItemMapper,
			       dalShoppingCartItemMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c376591abcc3fcee1a981bf6a2a358e8</Hash>
</Codenesium>*/