using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ProductModelRepository : AbstractProductModelRepository, IProductModelRepository
	{
		public ProductModelRepository(
			ILogger<ProductModelRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3c694ce4a6342a495800c3a84da0ee6f</Hash>
</Codenesium>*/