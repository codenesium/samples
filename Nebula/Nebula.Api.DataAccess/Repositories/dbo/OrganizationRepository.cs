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
				return this._context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFOrganization>();
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
				return this._context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFOrganization>();
			}
			else
			{
				return this._context.Set<EFOrganization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFOrganization>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>592a418f5ca029c16f2b2964e96332a3</Hash>
</Codenesium>*/