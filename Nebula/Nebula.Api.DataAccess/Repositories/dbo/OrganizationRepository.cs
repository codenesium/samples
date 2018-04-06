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
		                              ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFOrganization> SearchLinqEF(Expression<Func<EFOrganization, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFOrganization>();
			}
			else
			{
				return this._context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFOrganization>();
			}
		}

		protected override List<EFOrganization> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFOrganization>();
			}
			else
			{
				return this._context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFOrganization>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>b66f872aa0abe0cd10720a78c71d94e5</Hash>
</Codenesium>*/