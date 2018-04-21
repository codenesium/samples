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
			IObjectMapper mapper,
			ILogger<ShipMethodRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFShipMethod> SearchLinqEF(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFShipMethod>().Where(predicate).AsQueryable().OrderBy("ShipMethodID ASC").Skip(skip).Take(take).ToList<EFShipMethod>();
			}
			else
			{
				return this.Context.Set<EFShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShipMethod>();
			}
		}

		protected override List<EFShipMethod> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFShipMethod>().Where(predicate).AsQueryable().OrderBy("ShipMethodID ASC").Skip(skip).Take(take).ToList<EFShipMethod>();
			}
			else
			{
				return this.Context.Set<EFShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShipMethod>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>b46441d5f803644301cf73ca02872500</Hash>
</Codenesium>*/