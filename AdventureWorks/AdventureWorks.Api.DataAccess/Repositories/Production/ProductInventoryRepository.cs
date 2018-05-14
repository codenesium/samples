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
	public class ProductInventoryRepository: AbstractProductInventoryRepository, IProductInventoryRepository
	{
		public ProductInventoryRepository(
			IObjectMapper mapper,
			ILogger<ProductInventoryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>a827b635f87108ac94d62be043a47029</Hash>
</Codenesium>*/