using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class ShoppingCartItemService : AbstractShoppingCartItemService, IShoppingCartItemService
	{
		public ShoppingCartItemService(
			ILogger<IShoppingCartItemRepository> logger,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IApiShoppingCartItemRequestModelValidator shoppingCartItemModelValidator,
			IBOLShoppingCartItemMapper bolshoppingCartItemMapper,
			IDALShoppingCartItemMapper dalshoppingCartItemMapper
			)
			: base(logger,
			       shoppingCartItemRepository,
			       shoppingCartItemModelValidator,
			       bolshoppingCartItemMapper,
			       dalshoppingCartItemMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>45f38fdf4ac2c36e7e802f21c5193ac5</Hash>
</Codenesium>*/