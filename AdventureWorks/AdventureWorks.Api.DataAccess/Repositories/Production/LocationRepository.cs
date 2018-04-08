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
		public LocationRepository(ILogger<LocationRepository> logger,
		                          ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFLocation> SearchLinqEF(Expression<Func<EFLocation, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy("LocationID ASC").Skip(skip).Take(take).ToList<EFLocation>();
			}
			else
			{
				return this.context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLocation>();
			}
		}

		protected override List<EFLocation> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
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
    <Hash>67b783f0a54769ae54c94dc4a88f6929</Hash>
</Codenesium>*/