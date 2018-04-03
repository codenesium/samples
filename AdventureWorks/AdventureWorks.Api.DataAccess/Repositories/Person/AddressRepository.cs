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
	public class AddressRepository: AbstractAddressRepository, IAddressRepository
	{
		public AddressRepository(ILogger<AddressRepository> logger,
		                         ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFAddress> SearchLinqEF(Expression<Func<EFAddress, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFAddress>().Where(predicate).AsQueryable().OrderBy("addressID ASC").Skip(skip).Take(take).ToList<EFAddress>();
			}
			else
			{
				return this._context.Set<EFAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAddress>();
			}
		}

		protected override List<EFAddress> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFAddress>().Where(predicate).AsQueryable().OrderBy("addressID ASC").Skip(skip).Take(take).ToList<EFAddress>();
			}
			else
			{
				return this._context.Set<EFAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAddress>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>f5d5c69994c68c27fff6d9a05f57b4ad</Hash>
</Codenesium>*/