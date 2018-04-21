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
	public class ProductCategoryRepository: AbstractProductCategoryRepository, IProductCategoryRepository
	{
		public ProductCategoryRepository(
			IObjectMapper mapper,
			ILogger<ProductCategoryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFProductCategory> SearchLinqEF(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFProductCategory>().Where(predicate).AsQueryable().OrderBy("ProductCategoryID ASC").Skip(skip).Take(take).ToList<EFProductCategory>();
			}
			else
			{
				return this.Context.Set<EFProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductCategory>();
			}
		}

		protected override List<EFProductCategory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFProductCategory>().Where(predicate).AsQueryable().OrderBy("ProductCategoryID ASC").Skip(skip).Take(take).ToList<EFProductCategory>();
			}
			else
			{
				return this.Context.Set<EFProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductCategory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>cf1c38c9bf1fe366ac08813c052b3428</Hash>
</Codenesium>*/