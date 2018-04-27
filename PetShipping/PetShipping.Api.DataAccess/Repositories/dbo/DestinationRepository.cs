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
	public class DestinationRepository: AbstractDestinationRepository, IDestinationRepository
	{
		public DestinationRepository(
			IObjectMapper mapper,
			ILogger<DestinationRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFDestination> SearchLinqEF(Expression<Func<EFDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFDestination>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFDestination>();
			}
			else
			{
				return this.Context.Set<EFDestination>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDestination>();
			}
		}

		protected override List<EFDestination> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFDestination>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFDestination>();
			}
			else
			{
				return this.Context.Set<EFDestination>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDestination>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>9fe43497f4d7e5fe908119287bb6375c</Hash>
</Codenesium>*/