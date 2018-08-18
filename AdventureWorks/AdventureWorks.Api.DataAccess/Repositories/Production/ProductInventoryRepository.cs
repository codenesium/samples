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
	public partial class ProductInventoryRepository : AbstractProductInventoryRepository, IProductInventoryRepository
	{
		public ProductInventoryRepository(
			ILogger<ProductInventoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ec57daf6d03eee1aa5ad72c8c913131e</Hash>
</Codenesium>*/