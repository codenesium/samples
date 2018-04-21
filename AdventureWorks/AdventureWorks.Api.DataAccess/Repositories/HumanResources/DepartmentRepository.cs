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
	public class DepartmentRepository: AbstractDepartmentRepository, IDepartmentRepository
	{
		public DepartmentRepository(
			IObjectMapper mapper,
			ILogger<DepartmentRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFDepartment> SearchLinqEF(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFDepartment>().Where(predicate).AsQueryable().OrderBy("DepartmentID ASC").Skip(skip).Take(take).ToList<EFDepartment>();
			}
			else
			{
				return this.Context.Set<EFDepartment>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDepartment>();
			}
		}

		protected override List<EFDepartment> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFDepartment>().Where(predicate).AsQueryable().OrderBy("DepartmentID ASC").Skip(skip).Take(take).ToList<EFDepartment>();
			}
			else
			{
				return this.Context.Set<EFDepartment>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDepartment>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>dbf956ace704e23d4596432e9911af70</Hash>
</Codenesium>*/