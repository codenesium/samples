using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ShoppingCartItemRepository : AbstractShoppingCartItemRepository, IShoppingCartItemRepository
	{
		public ShoppingCartItemRepository(
			ILogger<ShoppingCartItemRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e284dbd9c8653dd1d5e34051eb8b369a</Hash>
</Codenesium>*/