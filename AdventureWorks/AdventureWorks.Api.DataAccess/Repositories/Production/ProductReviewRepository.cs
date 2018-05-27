using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductReviewRepository: AbstractProductReviewRepository, IProductReviewRepository
	{
		public ProductReviewRepository(
			IDALProductReviewMapper mapper,
			ILogger<ProductReviewRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>f732492b2f538a185b3c204c6235b338</Hash>
</Codenesium>*/