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
	public class OtherTransportRepository: AbstractOtherTransportRepository, IOtherTransportRepository
	{
		public OtherTransportRepository(
			IObjectMapper mapper,
			ILogger<OtherTransportRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFOtherTransport> SearchLinqEF(Expression<Func<EFOtherTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFOtherTransport>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFOtherTransport>();
			}
			else
			{
				return this.Context.Set<EFOtherTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFOtherTransport>();
			}
		}

		protected override List<EFOtherTransport> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFOtherTransport>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFOtherTransport>();
			}
			else
			{
				return this.Context.Set<EFOtherTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFOtherTransport>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>a67893ace619296a633f3a08ab226ae0</Hash>
</Codenesium>*/