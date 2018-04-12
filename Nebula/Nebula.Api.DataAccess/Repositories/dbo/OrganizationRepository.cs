using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class OrganizationRepository: AbstractOrganizationRepository, IOrganizationRepository
	{
		public OrganizationRepository(
			ILogger<OrganizationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFOrganization> SearchLinqEF(Expression<Func<EFOrganization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFOrganization>();
			}
			else
			{
				return this.context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFOrganization>();
			}
		}

		protected override List<EFOrganization> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFOrganization>();
			}
			else
			{
				return this.context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFOrganization>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>d2c447fcb525a75e3e7ea870d80d76f9</Hash>
</Codenesium>*/