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
	public class StateProvinceRepository: AbstractStateProvinceRepository, IStateProvinceRepository
	{
		public StateProvinceRepository(
			IObjectMapper mapper,
			ILogger<StateProvinceRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFStateProvince> SearchLinqEF(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy("StateProvinceID ASC").Skip(skip).Take(take).ToList<EFStateProvince>();
			}
			else
			{
				return this.context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStateProvince>();
			}
		}

		protected override List<EFStateProvince> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy("StateProvinceID ASC").Skip(skip).Take(take).ToList<EFStateProvince>();
			}
			else
			{
				return this.context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStateProvince>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>0e1a7727a5f19e8d9af362a752d17f0f</Hash>
</Codenesium>*/