using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class AirlineRepository: AbstractAirlineRepository, IAirlineRepository
	{
		public AirlineRepository(
			IObjectMapper mapper,
			ILogger<AirlineRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFAirline> SearchLinqEF(Expression<Func<EFAirline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFAirline>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFAirline>();
			}
			else
			{
				return this.Context.Set<EFAirline>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAirline>();
			}
		}

		protected override List<EFAirline> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFAirline>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFAirline>();
			}
			else
			{
				return this.Context.Set<EFAirline>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAirline>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>bbbc5c05d620320e855fb3ec3a8d5e63</Hash>
</Codenesium>*/