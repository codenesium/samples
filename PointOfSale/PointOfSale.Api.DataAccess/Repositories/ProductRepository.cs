using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.DataAccess
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
    <Hash>4c351ae1081d53d23ecc60995fe64eaf</Hash>
</Codenesium>*/