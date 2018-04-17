using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOProductListPriceHistory: AbstractBOProductListPriceHistory, IBOProductListPriceHistory
	{
		public BOProductListPriceHistory(
			ILogger<ProductListPriceHistoryRepository> logger,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IProductListPriceHistoryModelValidator productListPriceHistoryModelValidator)
			: base(logger, productListPriceHistoryRepository, productListPriceHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>39de3c5546c99d70bb3a0885552bbf68</Hash>
</Codenesium>*/