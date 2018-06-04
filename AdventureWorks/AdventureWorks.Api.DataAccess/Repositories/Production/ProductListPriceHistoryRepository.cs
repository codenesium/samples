using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductListPriceHistoryRepository: AbstractProductListPriceHistoryRepository, IProductListPriceHistoryRepository
	{
		public ProductListPriceHistoryRepository(
			ILogger<ProductListPriceHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>fce074f5204d94597e39733d39fe6363</Hash>
</Codenesium>*/