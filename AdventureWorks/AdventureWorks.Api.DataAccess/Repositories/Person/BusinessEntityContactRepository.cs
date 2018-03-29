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
	public class BusinessEntityContactRepository: AbstractBusinessEntityContactRepository, IBusinessEntityContactRepository
	{
		public BusinessEntityContactRepository(ILogger<BusinessEntityContactRepository> logger,
		                                       ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFBusinessEntityContact> SearchLinqEF(Expression<Func<EFBusinessEntityContact, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFBusinessEntityContact>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFBusinessEntityContact>();
			}
			else
			{
				return this._context.Set<EFBusinessEntityContact>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBusinessEntityContact>();
			}
		}

		protected override List<EFBusinessEntityContact> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFBusinessEntityContact>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFBusinessEntityContact>();
			}
			else
			{
				return this._context.Set<EFBusinessEntityContact>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBusinessEntityContact>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>8f7e0ceedd4d5364b3091ffdad330976</Hash>
</Codenesium>*/