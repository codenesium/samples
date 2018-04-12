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
		public ShipMethodRepository(
			ILogger<ShipMethodRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFShipMethod> SearchLinqEF(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFShipMethod>().Where(predicate).AsQueryable().OrderBy("ShipMethodID ASC").Skip(skip).Take(take).ToList<EFShipMethod>();
			}
			else
			{
				return this.context.Set<EFShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShipMethod>();
			}
		}

		protected override List<EFShipMethod> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFShipMethod>().Where(predicate).AsQueryable().OrderBy("ShipMethodID ASC").Skip(skip).Take(take).ToList<EFShipMethod>();
			}
			else
			{
				return this.context.Set<EFShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShipMethod>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>80338d257690544cfa05119e5550d781</Hash>
</Codenesium>*/