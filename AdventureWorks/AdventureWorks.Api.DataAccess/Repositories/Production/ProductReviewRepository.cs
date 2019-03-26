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
    <Hash>a2bec6cd88cf5c4081f90fce0752bd9b</Hash>
</Codenesium>*/