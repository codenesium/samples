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
		                                ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFBusinessEntity> SearchLinqEF(Expression<Func<EFBusinessEntity, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFBusinessEntity>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFBusinessEntity>();
			}
			else
			{
				return this._context.Set<EFBusinessEntity>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBusinessEntity>();
			}
		}

		protected override List<EFBusinessEntity> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFBusinessEntity>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFBusinessEntity>();
			}
			else
			{
				return this._context.Set<EFBusinessEntity>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBusinessEntity>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>3958b82c0d191eafbdb00ea7706084a6</Hash>
</Codenesium>*/