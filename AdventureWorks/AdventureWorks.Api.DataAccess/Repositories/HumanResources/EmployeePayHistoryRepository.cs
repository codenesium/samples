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
		                                    ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFEmployeePayHistory> SearchLinqEF(Expression<Func<EFEmployeePayHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFEmployeePayHistory>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFEmployeePayHistory>();
			}
			else
			{
				return this._context.Set<EFEmployeePayHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmployeePayHistory>();
			}
		}

		protected override List<EFEmployeePayHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFEmployeePayHistory>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFEmployeePayHistory>();
			}
			else
			{
				return this._context.Set<EFEmployeePayHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmployeePayHistory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>3a2200e0f612996de468b1e2370435d5</Hash>
</Codenesium>*/