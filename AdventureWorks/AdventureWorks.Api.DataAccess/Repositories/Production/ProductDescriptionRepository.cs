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
	public partial class ProductDescriptionRepository : AbstractProductDescriptionRepository, IProductDescriptionRepository
	{
		public ProductDescriptionRepository(
			ILogger<ProductDescriptionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>30585251406a230d54ecd9c7633063e6</Hash>
</Codenesium>*/