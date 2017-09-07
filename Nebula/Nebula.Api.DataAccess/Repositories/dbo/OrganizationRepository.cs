using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class OrganizationRepository: AbstractOrganizationRepository
	{
		public OrganizationRepository(ILogger logger,
		                              DbContext context) : base(logger,context)
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
    <Hash>b66575e69213fe68af68568f23c62f6c</Hash>
</Codenesium>*/