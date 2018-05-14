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
			IApiProductListPriceHistoryModelValidator productListPriceHistoryModelValidator)
			: base(logger, productListPriceHistoryRepository, productListPriceHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>4f246512d85c22d02b18fc2e04752230</Hash>
</Codenesium>*/