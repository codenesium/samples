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
    <Hash>df41c91ba17e5c173bce62b906cc2e71</Hash>
</Codenesium>*/