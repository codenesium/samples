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
			IApiProductCostHistoryRequestModelValidator productCostHistoryModelValidator,
			IBOLProductCostHistoryMapper productCostHistoryMapper)
			: base(logger, productCostHistoryRepository, productCostHistoryModelValidator, productCostHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>db10ba9ec19e5ec07de34bf0e2c0340b</Hash>
</Codenesium>*/