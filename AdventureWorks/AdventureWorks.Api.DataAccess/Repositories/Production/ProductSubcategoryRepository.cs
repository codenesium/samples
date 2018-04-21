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
			IObjectMapper mapper,
			ILogger<ProductSubcategoryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFProductSubcategory> SearchLinqEF(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy("ProductSubcategoryID ASC").Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
			else
			{
				return this.Context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
		}

		protected override List<EFProductSubcategory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy("ProductSubcategoryID ASC").Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
			else
			{
				return this.Context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>eacb11a89eb403e56531f3dd0779e8e2</Hash>
</Codenesium>*/