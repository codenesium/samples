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
	public class EmployeeRepository: AbstractEmployeeRepository, IEmployeeRepository
	{
		public EmployeeRepository(ILogger<EmployeeRepository> logger,
		                          ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFEmployee> SearchLinqEF(Expression<Func<EFEmployee, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFEmployee>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFEmployee>();
			}
			else
			{
				return this._context.Set<EFEmployee>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmployee>();
			}
		}

		protected override List<EFEmployee> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFEmployee>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFEmployee>();
			}
			else
			{
				return this._context.Set<EFEmployee>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmployee>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>cc5d41ecc2ce2201a81260b7a5d73ae5</Hash>
</Codenesium>*/