using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class AdminRepository: AbstractAdminRepository, IAdminRepository
	{
		public AdminRepository(
			IObjectMapper mapper,
			ILogger<AdminRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFAdmin> SearchLinqEF(Expression<Func<EFAdmin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFAdmin>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFAdmin>();
			}
			else
			{
				return this.context.Set<EFAdmin>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAdmin>();
			}
		}

		protected override List<EFAdmin> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFAdmin>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFAdmin>();
			}
			else
			{
				return this.context.Set<EFAdmin>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAdmin>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>c7b261ab0935e732f6a3c76853adc7e5</Hash>
</Codenesium>*/