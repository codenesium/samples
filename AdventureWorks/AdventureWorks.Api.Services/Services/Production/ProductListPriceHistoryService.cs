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
	public partial class ProductListPriceHistoryService : AbstractProductListPriceHistoryService, IProductListPriceHistoryService
	{
		public ProductListPriceHistoryService(
			ILogger<IProductListPriceHistoryRepository> logger,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IApiProductListPriceHistoryRequestModelValidator productListPriceHistoryModelValidator,
			IBOLProductListPriceHistoryMapper bolproductListPriceHistoryMapper,
			IDALProductListPriceHistoryMapper dalproductListPriceHistoryMapper)
			: base(logger,
			       productListPriceHistoryRepository,
			       productListPriceHistoryModelValidator,
			       bolproductListPriceHistoryMapper,
			       dalproductListPriceHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fc5d1a3da86dd6b38f778f363ac6ba61</Hash>
</Codenesium>*/