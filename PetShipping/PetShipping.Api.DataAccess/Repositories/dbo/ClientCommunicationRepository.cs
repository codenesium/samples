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
	public class ClientCommunicationRepository: AbstractClientCommunicationRepository, IClientCommunicationRepository
	{
		public ClientCommunicationRepository(
			IObjectMapper mapper,
			ILogger<ClientCommunicationRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFClientCommunication> SearchLinqEF(Expression<Func<EFClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFClientCommunication>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFClientCommunication>();
			}
			else
			{
				return this.Context.Set<EFClientCommunication>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFClientCommunication>();
			}
		}

		protected override List<EFClientCommunication> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFClientCommunication>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFClientCommunication>();
			}
			else
			{
				return this.Context.Set<EFClientCommunication>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFClientCommunication>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>03e1dad76c089a923b509a45e4452190</Hash>
</Codenesium>*/