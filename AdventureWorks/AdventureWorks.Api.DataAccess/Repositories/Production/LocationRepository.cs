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
	public class LocationRepository: AbstractLocationRepository, ILocationRepository
	{
		public LocationRepository(
			IObjectMapper mapper,
			ILogger<LocationRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFLocation> SearchLinqEF(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy("LocationID ASC").Skip(skip).Take(take).ToList<EFLocation>();
			}
			else
			{
				return this.context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLocation>();
			}
		}

		protected override List<EFLocation> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy("LocationID ASC").Skip(skip).Take(take).ToList<EFLocation>();
			}
			else
			{
				return this.context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLocation>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>993ffa8a17843a23413b56253c54eeff</Hash>
</Codenesium>*/