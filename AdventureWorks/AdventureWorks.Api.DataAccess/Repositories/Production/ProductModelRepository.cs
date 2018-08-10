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
    <Hash>2f9e3a0f47119978bdc455a54f304f75</Hash>
</Codenesium>*/