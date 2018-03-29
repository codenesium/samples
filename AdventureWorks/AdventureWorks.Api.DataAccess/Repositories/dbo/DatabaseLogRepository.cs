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
		public DatabaseLogRepository(ILogger<DatabaseLogRepository> logger,
		                             ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFDatabaseLog> SearchLinqEF(Expression<Func<EFDatabaseLog, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFDatabaseLog>().Where(predicate).AsQueryable().OrderBy("DatabaseLogID ASC").Skip(skip).Take(take).ToList<EFDatabaseLog>();
			}
			else
			{
				return this._context.Set<EFDatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDatabaseLog>();
			}
		}

		protected override List<EFDatabaseLog> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFDatabaseLog>().Where(predicate).AsQueryable().OrderBy("DatabaseLogID ASC").Skip(skip).Take(take).ToList<EFDatabaseLog>();
			}
			else
			{
				return this._context.Set<EFDatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDatabaseLog>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>738db97a8a11dcc2ebe68cfd5356d485</Hash>
</Codenesium>*/