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
		                                       ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFBusinessEntityAddress> SearchLinqEF(Expression<Func<EFBusinessEntityAddress, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFBusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFBusinessEntityAddress>();
			}
			else
			{
				return this.context.Set<EFBusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBusinessEntityAddress>();
			}
		}

		protected override List<EFBusinessEntityAddress> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFBusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFBusinessEntityAddress>();
			}
			else
			{
				return this.context.Set<EFBusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBusinessEntityAddress>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e50a91287b264d988943fe617e14e213</Hash>
</Codenesium>*/