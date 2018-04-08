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
		public OrganizationRepository(ILogger<OrganizationRepository> logger,
		                              ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFOrganization> SearchLinqEF(Expression<Func<EFOrganization, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFOrganization>();
			}
			else
			{
				return this.context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFOrganization>();
			}
		}

		protected override List<EFOrganization> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
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
    <Hash>95b873156eede38e327b1cd6033615b0</Hash>
</Codenesium>*/