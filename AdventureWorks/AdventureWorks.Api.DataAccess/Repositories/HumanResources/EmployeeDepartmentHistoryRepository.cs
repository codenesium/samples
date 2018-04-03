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
	public class EmployeeDepartmentHistoryRepository: AbstractEmployeeDepartmentHistoryRepository, IEmployeeDepartmentHistoryRepository
	{
		public EmployeeDepartmentHistoryRepository(ILogger<EmployeeDepartmentHistoryRepository> logger,
		                                           ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFEmployeeDepartmentHistory> SearchLinqEF(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFEmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFEmployeeDepartmentHistory>();
			}
			else
			{
				return this._context.Set<EFEmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmployeeDepartmentHistory>();
			}
		}

		protected override List<EFEmployeeDepartmentHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFEmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFEmployeeDepartmentHistory>();
			}
			else
			{
				return this._context.Set<EFEmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmployeeDepartmentHistory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>88b79c13b0f2bc3613c7860d9bb15387</Hash>
</Codenesium>*/