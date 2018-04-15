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
	public class EmailAddressRepository: AbstractEmailAddressRepository, IEmailAddressRepository
	{
		public EmailAddressRepository(
			IObjectMapper mapper,
			ILogger<EmailAddressRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFEmailAddress> SearchLinqEF(Expression<Func<EFEmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFEmailAddress>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFEmailAddress>();
			}
			else
			{
				return this.context.Set<EFEmailAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmailAddress>();
			}
		}

		protected override List<EFEmailAddress> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFEmailAddress>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFEmailAddress>();
			}
			else
			{
				return this.context.Set<EFEmailAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmailAddress>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>cd95dfff267cca3eca38d91960afd7a2</Hash>
</Codenesium>*/