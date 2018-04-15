using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class SpaceRepository: AbstractSpaceRepository, ISpaceRepository
	{
		public SpaceRepository(
			IObjectMapper mapper,
			ILogger<SpaceRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFSpace> SearchLinqEF(Expression<Func<EFSpace, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSpace>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFSpace>();
			}
			else
			{
				return this.context.Set<EFSpace>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSpace>();
			}
		}

		protected override List<EFSpace> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSpace>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFSpace>();
			}
			else
			{
				return this.context.Set<EFSpace>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSpace>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>8f8b6a59905da2053e00d8b9094a9df2</Hash>
</Codenesium>*/