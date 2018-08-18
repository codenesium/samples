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
	public partial class ProductVendorRepository : AbstractProductVendorRepository, IProductVendorRepository
	{
		public ProductVendorRepository(
			ILogger<ProductVendorRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>78f69db05d0e3b5d5b42283ec92811a7</Hash>
</Codenesium>*/