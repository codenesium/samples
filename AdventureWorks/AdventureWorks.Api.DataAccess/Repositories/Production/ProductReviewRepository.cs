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
	public partial class ProductReviewRepository : AbstractProductReviewRepository, IProductReviewRepository
	{
		public ProductReviewRepository(
			ILogger<ProductReviewRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ff2ff4e21df060ec49d26cd522c6962c</Hash>
</Codenesium>*/