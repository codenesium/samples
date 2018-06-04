using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductInventoryRepository: AbstractProductInventoryRepository, IProductInventoryRepository
	{
		public ProductInventoryRepository(
			ILogger<ProductInventoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>6a731273f10265abf337ea490d5f15f3</Hash>
</Codenesium>*/