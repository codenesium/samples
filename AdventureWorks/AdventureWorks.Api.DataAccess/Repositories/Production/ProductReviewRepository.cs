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
			IObjectMapper mapper,
			ILogger<ProductReviewRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFProductReview> SearchLinqEF(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductReview>().Where(predicate).AsQueryable().OrderBy("ProductReviewID ASC").Skip(skip).Take(take).ToList<EFProductReview>();
			}
			else
			{
				return this.context.Set<EFProductReview>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductReview>();
			}
		}

		protected override List<EFProductReview> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductReview>().Where(predicate).AsQueryable().OrderBy("ProductReviewID ASC").Skip(skip).Take(take).ToList<EFProductReview>();
			}
			else
			{
				return this.context.Set<EFProductReview>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductReview>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>67c5d4224593fd02b4106c5c8a801401</Hash>
</Codenesium>*/