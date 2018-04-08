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
		                                           ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFEmployeeDepartmentHistory> SearchLinqEF(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFEmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFEmployeeDepartmentHistory>();
			}
			else
			{
				return this.context.Set<EFEmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmployeeDepartmentHistory>();
			}
		}

		protected override List<EFEmployeeDepartmentHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFEmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFEmployeeDepartmentHistory>();
			}
			else
			{
				return this.context.Set<EFEmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmployeeDepartmentHistory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>06c02f8dd1603ed661b7f413c0f4a05f</Hash>
</Codenesium>*/