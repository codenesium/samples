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
	public class ClientRepository: AbstractClientRepository, IClientRepository
	{
		public ClientRepository(
			IObjectMapper mapper,
			ILogger<ClientRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFClient> SearchLinqEF(Expression<Func<EFClient, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFClient>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFClient>();
			}
			else
			{
				return this.Context.Set<EFClient>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFClient>();
			}
		}

		protected override List<EFClient> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFClient>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFClient>();
			}
			else
			{
				return this.Context.Set<EFClient>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFClient>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>2fabb721ed0a52afe469c59ffea166bf</Hash>
</Codenesium>*/