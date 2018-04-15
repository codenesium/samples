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
	public class PasswordRepository: AbstractPasswordRepository, IPasswordRepository
	{
		public PasswordRepository(
			IObjectMapper mapper,
			ILogger<PasswordRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFPassword> SearchLinqEF(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPassword>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFPassword>();
			}
			else
			{
				return this.context.Set<EFPassword>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPassword>();
			}
		}

		protected override List<EFPassword> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPassword>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFPassword>();
			}
			else
			{
				return this.context.Set<EFPassword>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPassword>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>3b51753a7078fd96c8f0fc5f7efc1ba0</Hash>
</Codenesium>*/