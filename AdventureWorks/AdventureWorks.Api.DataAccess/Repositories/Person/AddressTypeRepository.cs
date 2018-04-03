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
	public class AddressTypeRepository: AbstractAddressTypeRepository, IAddressTypeRepository
	{
		public AddressTypeRepository(ILogger<AddressTypeRepository> logger,
		                             ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFAddressType> SearchLinqEF(Expression<Func<EFAddressType, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFAddressType>().Where(predicate).AsQueryable().OrderBy("addressTypeID ASC").Skip(skip).Take(take).ToList<EFAddressType>();
			}
			else
			{
				return this._context.Set<EFAddressType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAddressType>();
			}
		}

		protected override List<EFAddressType> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFAddressType>().Where(predicate).AsQueryable().OrderBy("addressTypeID ASC").Skip(skip).Take(take).ToList<EFAddressType>();
			}
			else
			{
				return this._context.Set<EFAddressType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAddressType>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>4c8e49009149c8085f21ca1f11754c9c</Hash>
</Codenesium>*/