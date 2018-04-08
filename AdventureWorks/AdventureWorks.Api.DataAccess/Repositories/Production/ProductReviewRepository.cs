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
		public ProductReviewRepository(ILogger<ProductReviewRepository> logger,
		                               ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFProductReview> SearchLinqEF(Expression<Func<EFProductReview, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductReview>().Where(predicate).AsQueryable().OrderBy("ProductReviewID ASC").Skip(skip).Take(take).ToList<EFProductReview>();
			}
			else
			{
				return this.context.Set<EFProductReview>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductReview>();
			}
		}

		protected override List<EFProductReview> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
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
    <Hash>c4223b41d9929dc4f3ac0cdab3da78fe</Hash>
</Codenesium>*/