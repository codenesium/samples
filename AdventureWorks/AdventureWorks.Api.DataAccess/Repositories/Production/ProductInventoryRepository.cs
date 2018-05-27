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
			IDALProductInventoryMapper mapper,
			ILogger<ProductInventoryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>863247bfe4996ba8e9e49f3995df785c</Hash>
</Codenesium>*/