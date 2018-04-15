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
	public class PersonPhoneRepository: AbstractPersonPhoneRepository, IPersonPhoneRepository
	{
		public PersonPhoneRepository(
			IObjectMapper mapper,
			ILogger<PersonPhoneRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFPersonPhone> SearchLinqEF(Expression<Func<EFPersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPersonPhone>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFPersonPhone>();
			}
			else
			{
				return this.context.Set<EFPersonPhone>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPersonPhone>();
			}
		}

		protected override List<EFPersonPhone> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPersonPhone>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFPersonPhone>();
			}
			else
			{
				return this.context.Set<EFPersonPhone>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPersonPhone>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e4513ec1c4b8f1a406b6b40fd5856c6a</Hash>
</Codenesium>*/