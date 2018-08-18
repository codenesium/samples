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
    <Hash>b1a4a50d0d2d142e138e0f52210f530a</Hash>
</Codenesium>*/