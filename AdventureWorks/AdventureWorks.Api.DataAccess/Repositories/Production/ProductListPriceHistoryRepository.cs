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
	public partial class ProductListPriceHistoryRepository : AbstractProductListPriceHistoryRepository, IProductListPriceHistoryRepository
	{
		public ProductListPriceHistoryRepository(
			ILogger<ProductListPriceHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b780ae248c463c9e112899097d83f133</Hash>
</Codenesium>*/