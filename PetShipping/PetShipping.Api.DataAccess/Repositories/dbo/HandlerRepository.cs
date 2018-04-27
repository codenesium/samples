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
	public class HandlerRepository: AbstractHandlerRepository, IHandlerRepository
	{
		public HandlerRepository(
			IObjectMapper mapper,
			ILogger<HandlerRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFHandler> SearchLinqEF(Expression<Func<EFHandler, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFHandler>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFHandler>();
			}
			else
			{
				return this.Context.Set<EFHandler>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFHandler>();
			}
		}

		protected override List<EFHandler> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFHandler>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFHandler>();
			}
			else
			{
				return this.Context.Set<EFHandler>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFHandler>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>0bc5ebe33bfbebc92262167f00117943</Hash>
</Codenesium>*/