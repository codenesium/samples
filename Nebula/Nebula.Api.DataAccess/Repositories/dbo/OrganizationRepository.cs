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

		protected override List<Organization> SearchLinqEF(Expression<Func<Organization, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Organization>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Organization>();
			}
			else
			{
				return this._context.Set<Organization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Organization>();
			}
		}

		protected override List<Organization> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Organization>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Organization>();
			}
			else
			{
				return this._context.Set<Organization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Organization>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>6d1a8f31a2d8f6601a4a1a082ee16e84</Hash>
</Codenesium>*/