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
	public class ProductVendorRepository: AbstractProductVendorRepository, IProductVendorRepository
	{
		public ProductVendorRepository(
			IObjectMapper mapper,
			ILogger<ProductVendorRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFProductVendor> SearchLinqEF(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductVendor>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductVendor>();
			}
			else
			{
				return this.context.Set<EFProductVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductVendor>();
			}
		}

		protected override List<EFProductVendor> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductVendor>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductVendor>();
			}
			else
			{
				return this.context.Set<EFProductVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductVendor>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>2494acd672e90b0c4d1507285cc890e9</Hash>
</Codenesium>*/