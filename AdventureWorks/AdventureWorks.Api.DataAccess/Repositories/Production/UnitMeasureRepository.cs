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
	public class UnitMeasureRepository: AbstractUnitMeasureRepository, IUnitMeasureRepository
	{
		public UnitMeasureRepository(
			IObjectMapper mapper,
			ILogger<UnitMeasureRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFUnitMeasure> SearchLinqEF(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFUnitMeasure>().Where(predicate).AsQueryable().OrderBy("UnitMeasureCode ASC").Skip(skip).Take(take).ToList<EFUnitMeasure>();
			}
			else
			{
				return this.context.Set<EFUnitMeasure>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFUnitMeasure>();
			}
		}

		protected override List<EFUnitMeasure> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFUnitMeasure>().Where(predicate).AsQueryable().OrderBy("UnitMeasureCode ASC").Skip(skip).Take(take).ToList<EFUnitMeasure>();
			}
			else
			{
				return this.context.Set<EFUnitMeasure>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFUnitMeasure>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>cf392609a8f70f4237b8d8b8624285b3</Hash>
</Codenesium>*/