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
	public class CountryRegionRepository: AbstractCountryRegionRepository, ICountryRegionRepository
	{
		public CountryRegionRepository(
			IObjectMapper mapper,
			ILogger<CountryRegionRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFCountryRegion> SearchLinqEF(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCountryRegion>().Where(predicate).AsQueryable().OrderBy("CountryRegionCode ASC").Skip(skip).Take(take).ToList<EFCountryRegion>();
			}
			else
			{
				return this.context.Set<EFCountryRegion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCountryRegion>();
			}
		}

		protected override List<EFCountryRegion> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCountryRegion>().Where(predicate).AsQueryable().OrderBy("CountryRegionCode ASC").Skip(skip).Take(take).ToList<EFCountryRegion>();
			}
			else
			{
				return this.context.Set<EFCountryRegion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCountryRegion>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e3b33592829494a5561f7117290bee14</Hash>
</Codenesium>*/