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
	public class EmployeePayHistoryRepository: AbstractEmployeePayHistoryRepository, IEmployeePayHistoryRepository
	{
		public EmployeePayHistoryRepository(ILogger<EmployeePayHistoryRepository> logger,
		                                    ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFEmployeePayHistory> SearchLinqEF(Expression<Func<EFEmployeePayHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFEmployeePayHistory>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFEmployeePayHistory>();
			}
			else
			{
				return this.context.Set<EFEmployeePayHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmployeePayHistory>();
			}
		}

		protected override List<EFEmployeePayHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFEmployeePayHistory>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFEmployeePayHistory>();
			}
			else
			{
				return this.context.Set<EFEmployeePayHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmployeePayHistory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>2420b644d76b673c6e851696a1d700a7</Hash>
</Codenesium>*/