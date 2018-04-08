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
	public class BusinessEntityRepository: AbstractBusinessEntityRepository, IBusinessEntityRepository
	{
		public BusinessEntityRepository(ILogger<BusinessEntityRepository> logger,
		                                ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFBusinessEntity> SearchLinqEF(Expression<Func<EFBusinessEntity, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFBusinessEntity>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFBusinessEntity>();
			}
			else
			{
				return this.context.Set<EFBusinessEntity>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBusinessEntity>();
			}
		}

		protected override List<EFBusinessEntity> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFBusinessEntity>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFBusinessEntity>();
			}
			else
			{
				return this.context.Set<EFBusinessEntity>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBusinessEntity>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>f945b2c912dccedda2c218fda1afa099</Hash>
</Codenesium>*/