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
	public class ErrorLogRepository: AbstractErrorLogRepository, IErrorLogRepository
	{
		public ErrorLogRepository(
			IObjectMapper mapper,
			ILogger<ErrorLogRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFErrorLog> SearchLinqEF(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFErrorLog>().Where(predicate).AsQueryable().OrderBy("ErrorLogID ASC").Skip(skip).Take(take).ToList<EFErrorLog>();
			}
			else
			{
				return this.context.Set<EFErrorLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFErrorLog>();
			}
		}

		protected override List<EFErrorLog> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFErrorLog>().Where(predicate).AsQueryable().OrderBy("ErrorLogID ASC").Skip(skip).Take(take).ToList<EFErrorLog>();
			}
			else
			{
				return this.context.Set<EFErrorLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFErrorLog>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>5154423b0f3da75ef4e11e8c2bb1142b</Hash>
</Codenesium>*/