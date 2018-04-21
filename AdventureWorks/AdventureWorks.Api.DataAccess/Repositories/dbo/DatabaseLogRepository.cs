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
	public class DatabaseLogRepository: AbstractDatabaseLogRepository, IDatabaseLogRepository
	{
		public DatabaseLogRepository(
			IObjectMapper mapper,
			ILogger<DatabaseLogRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFDatabaseLog> SearchLinqEF(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFDatabaseLog>().Where(predicate).AsQueryable().OrderBy("DatabaseLogID ASC").Skip(skip).Take(take).ToList<EFDatabaseLog>();
			}
			else
			{
				return this.Context.Set<EFDatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDatabaseLog>();
			}
		}

		protected override List<EFDatabaseLog> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFDatabaseLog>().Where(predicate).AsQueryable().OrderBy("DatabaseLogID ASC").Skip(skip).Take(take).ToList<EFDatabaseLog>();
			}
			else
			{
				return this.Context.Set<EFDatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDatabaseLog>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>60ab0a5518a8740d1f4b9a414453265a</Hash>
</Codenesium>*/