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
			IApiProductCostHistoryModelValidator productCostHistoryModelValidator)
			: base(logger, productCostHistoryRepository, productCostHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>96c8efa4ffbd09bc6a945a729fba4fd4</Hash>
</Codenesium>*/