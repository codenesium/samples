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
	public class ProductDescriptionRepository: AbstractProductDescriptionRepository, IProductDescriptionRepository
	{
		public ProductDescriptionRepository(
			IObjectMapper mapper,
			ILogger<ProductDescriptionRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFProductDescription> SearchLinqEF(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFProductDescription>().Where(predicate).AsQueryable().OrderBy("ProductDescriptionID ASC").Skip(skip).Take(take).ToList<EFProductDescription>();
			}
			else
			{
				return this.Context.Set<EFProductDescription>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductDescription>();
			}
		}

		protected override List<EFProductDescription> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFProductDescription>().Where(predicate).AsQueryable().OrderBy("ProductDescriptionID ASC").Skip(skip).Take(take).ToList<EFProductDescription>();
			}
			else
			{
				return this.Context.Set<EFProductDescription>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductDescription>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>bf54adcfa9b8ef2f4542ad44a04afd26</Hash>
</Codenesium>*/