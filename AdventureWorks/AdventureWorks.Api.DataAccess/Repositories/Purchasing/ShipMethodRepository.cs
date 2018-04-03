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
	public class ShipMethodRepository: AbstractShipMethodRepository, IShipMethodRepository
	{
		public ShipMethodRepository(ILogger<ShipMethodRepository> logger,
		                            ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFShipMethod> SearchLinqEF(Expression<Func<EFShipMethod, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFShipMethod>().Where(predicate).AsQueryable().OrderBy("shipMethodID ASC").Skip(skip).Take(take).ToList<EFShipMethod>();
			}
			else
			{
				return this._context.Set<EFShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShipMethod>();
			}
		}

		protected override List<EFShipMethod> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFShipMethod>().Where(predicate).AsQueryable().OrderBy("shipMethodID ASC").Skip(skip).Take(take).ToList<EFShipMethod>();
			}
			else
			{
				return this._context.Set<EFShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShipMethod>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>3957f1f58f9d2fae1b0f00c2de2f409a</Hash>
</Codenesium>*/