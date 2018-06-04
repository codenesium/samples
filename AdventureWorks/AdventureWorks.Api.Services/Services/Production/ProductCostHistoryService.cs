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
	public class ProductCostHistoryService: AbstractProductCostHistoryService, IProductCostHistoryService
	{
		public ProductCostHistoryService(
			ILogger<ProductCostHistoryRepository> logger,
			IProductCostHistoryRepository productCostHistoryRepository,
			IApiProductCostHistoryRequestModelValidator productCostHistoryModelValidator,
			IBOLProductCostHistoryMapper BOLproductCostHistoryMapper,
			IDALProductCostHistoryMapper DALproductCostHistoryMapper)
			: base(logger, productCostHistoryRepository,
			       productCostHistoryModelValidator,
			       BOLproductCostHistoryMapper,
			       DALproductCostHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>31111a97b5aeae6e6294b17c1c86b1af</Hash>
</Codenesium>*/