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
	public class AirTransportRepository: AbstractAirTransportRepository, IAirTransportRepository
	{
		public AirTransportRepository(
			IObjectMapper mapper,
			ILogger<AirTransportRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFAirTransport> SearchLinqEF(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFAirTransport>().Where(predicate).AsQueryable().OrderBy("AirlineId ASC").Skip(skip).Take(take).ToList<EFAirTransport>();
			}
			else
			{
				return this.Context.Set<EFAirTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAirTransport>();
			}
		}

		protected override List<EFAirTransport> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFAirTransport>().Where(predicate).AsQueryable().OrderBy("AirlineId ASC").Skip(skip).Take(take).ToList<EFAirTransport>();
			}
			else
			{
				return this.Context.Set<EFAirTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAirTransport>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>0179fc0e80427ceb1804be07442b6473</Hash>
</Codenesium>*/