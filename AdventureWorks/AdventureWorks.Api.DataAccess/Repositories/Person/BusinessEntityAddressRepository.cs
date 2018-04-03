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
	public class BusinessEntityAddressRepository: AbstractBusinessEntityAddressRepository, IBusinessEntityAddressRepository
	{
		public BusinessEntityAddressRepository(ILogger<BusinessEntityAddressRepository> logger,
		                                       ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFBusinessEntityAddress> SearchLinqEF(Expression<Func<EFBusinessEntityAddress, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFBusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFBusinessEntityAddress>();
			}
			else
			{
				return this._context.Set<EFBusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBusinessEntityAddress>();
			}
		}

		protected override List<EFBusinessEntityAddress> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFBusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFBusinessEntityAddress>();
			}
			else
			{
				return this._context.Set<EFBusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBusinessEntityAddress>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>2dd84d8ab6f35168f4570a1f3a201284</Hash>
</Codenesium>*/