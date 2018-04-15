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
				return this.context.Set<EFProductCategory>().Where(predicate).AsQueryable().OrderBy("ProductCategoryID ASC").Skip(skip).Take(take).ToList<EFProductCategory>();
			}
			else
			{
				return this.context.Set<EFProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductCategory>();
			}
		}

		protected override List<EFProductCategory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductCategory>().Where(predicate).AsQueryable().OrderBy("ProductCategoryID ASC").Skip(skip).Take(take).ToList<EFProductCategory>();
			}
			else
			{
				return this.context.Set<EFProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductCategory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>9c70c21f53cf8b5957438190d6ee0936</Hash>
</Codenesium>*/