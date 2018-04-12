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
	public class ProductSubcategoryRepository: AbstractProductSubcategoryRepository, IProductSubcategoryRepository
	{
		public ProductSubcategoryRepository(
			ILogger<ProductSubcategoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFProductSubcategory> SearchLinqEF(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy("ProductSubcategoryID ASC").Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
			else
			{
				return this.context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
		}

		protected override List<EFProductSubcategory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy("ProductSubcategoryID ASC").Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
			else
			{
				return this.context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>fc3126573a67394f5d97b245f3e09868</Hash>
</Codenesium>*/