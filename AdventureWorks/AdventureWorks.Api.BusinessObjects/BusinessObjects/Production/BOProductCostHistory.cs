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
	public class BOProductCostHistory: AbstractBOProductCostHistory, IBOProductCostHistory
	{
		public BOProductCostHistory(
			ILogger<ProductCostHistoryRepository> logger,
			IProductCostHistoryRepository productCostHistoryRepository,
			IProductCostHistoryModelValidator productCostHistoryModelValidator)
			: base(logger, productCostHistoryRepository, productCostHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>71746accb0e3dc3ad004e37f00055d11</Hash>
</Codenesium>*/