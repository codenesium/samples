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
			IApiProductListPriceHistoryRequestModelValidator productListPriceHistoryModelValidator,
			IBOLProductListPriceHistoryMapper productListPriceHistoryMapper)
			: base(logger, productListPriceHistoryRepository, productListPriceHistoryModelValidator, productListPriceHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>ce0ad2f7f329ed943a5fe3c5fbc885a1</Hash>
</Codenesium>*/