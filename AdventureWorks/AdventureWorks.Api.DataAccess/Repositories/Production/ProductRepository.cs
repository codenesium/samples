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
	public class ProductRepository: AbstractProductRepository, IProductRepository
	{
		public ProductRepository(
			IDALProductMapper mapper,
			ILogger<ProductRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>4d2ff786b2c03813130b6aad997cb52b</Hash>
</Codenesium>*/