using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>dd0ac3b057ab94b5c9abb7ae915e62e6</Hash>
</Codenesium>*/