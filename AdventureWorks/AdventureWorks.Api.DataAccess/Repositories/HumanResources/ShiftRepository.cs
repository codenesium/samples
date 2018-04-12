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
	public class ShiftRepository: AbstractShiftRepository, IShiftRepository
	{
		public ShiftRepository(
			ILogger<ShiftRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFShift> SearchLinqEF(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFShift>().Where(predicate).AsQueryable().OrderBy("ShiftID ASC").Skip(skip).Take(take).ToList<EFShift>();
			}
			else
			{
				return this.context.Set<EFShift>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShift>();
			}
		}

		protected override List<EFShift> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFShift>().Where(predicate).AsQueryable().OrderBy("ShiftID ASC").Skip(skip).Take(take).ToList<EFShift>();
			}
			else
			{
				return this.context.Set<EFShift>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShift>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>795470ef645fff6d2d4a3db3161159c1</Hash>
</Codenesium>*/