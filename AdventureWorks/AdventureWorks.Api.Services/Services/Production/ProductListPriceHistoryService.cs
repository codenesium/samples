using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ProductListPriceHistoryService: AbstractProductListPriceHistoryService, IProductListPriceHistoryService
	{
		public ProductListPriceHistoryService(
			ILogger<ProductListPriceHistoryRepository> logger,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IApiProductListPriceHistoryRequestModelValidator productListPriceHistoryModelValidator,
			IBOLProductListPriceHistoryMapper BOLproductListPriceHistoryMapper,
			IDALProductListPriceHistoryMapper DALproductListPriceHistoryMapper)
			: base(logger, productListPriceHistoryRepository,
			       productListPriceHistoryModelValidator,
			       BOLproductListPriceHistoryMapper,
			       DALproductListPriceHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>2b93dcf33b84c9f83039105d08095b46</Hash>
</Codenesium>*/