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
		public ShiftRepository(ILogger<ShiftRepository> logger,
		                       ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFShift> SearchLinqEF(Expression<Func<EFShift, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFShift>().Where(predicate).AsQueryable().OrderBy("ShiftID ASC").Skip(skip).Take(take).ToList<EFShift>();
			}
			else
			{
				return this._context.Set<EFShift>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShift>();
			}
		}

		protected override List<EFShift> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFShift>().Where(predicate).AsQueryable().OrderBy("ShiftID ASC").Skip(skip).Take(take).ToList<EFShift>();
			}
			else
			{
				return this._context.Set<EFShift>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShift>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>6a3ec1e210b57ad6f456275947ee5d2f</Hash>
</Codenesium>*/