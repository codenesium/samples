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
	public partial class ProductSubcategoryRepository : AbstractProductSubcategoryRepository, IProductSubcategoryRepository
	{
		public ProductSubcategoryRepository(
			ILogger<ProductSubcategoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bdb18aab4cbdef374beb382ae4e81d24</Hash>
</Codenesium>*/