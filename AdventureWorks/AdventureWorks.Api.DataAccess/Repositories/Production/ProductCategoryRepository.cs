using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ProductCategoryRepository : AbstractProductCategoryRepository, IProductCategoryRepository
	{
		public ProductCategoryRepository(
			ILogger<ProductCategoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>aab6166d9b3a7fb4428d54121effb056</Hash>
</Codenesium>*/