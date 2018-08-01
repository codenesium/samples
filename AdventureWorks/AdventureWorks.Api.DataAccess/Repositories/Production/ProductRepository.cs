using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ProductRepository : AbstractProductRepository, IProductRepository
	{
		public ProductRepository(
			ILogger<ProductRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d840e4bea3ffbc26b9b0fd1d83cdb2a3</Hash>
</Codenesium>*/