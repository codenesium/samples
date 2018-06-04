using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductCostHistoryRepository: AbstractProductCostHistoryRepository, IProductCostHistoryRepository
	{
		public ProductCostHistoryRepository(
			ILogger<ProductCostHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>151df1ccc93d2586a28906dd5b7b1e6c</Hash>
</Codenesium>*/