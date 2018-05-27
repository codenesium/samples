using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductCostHistoryRepository: AbstractProductCostHistoryRepository, IProductCostHistoryRepository
	{
		public ProductCostHistoryRepository(
			IDALProductCostHistoryMapper mapper,
			ILogger<ProductCostHistoryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>31b2156576084dedc56676ee0005c9f7</Hash>
</Codenesium>*/