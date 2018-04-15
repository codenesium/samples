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
	public class SpaceXSpaceFeatureRepository: AbstractSpaceXSpaceFeatureRepository, ISpaceXSpaceFeatureRepository
	{
		public SpaceXSpaceFeatureRepository(
			IObjectMapper mapper,
			ILogger<SpaceXSpaceFeatureRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFSpaceXSpaceFeature> SearchLinqEF(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFSpaceXSpaceFeature>();
			}
			else
			{
				return this.context.Set<EFSpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSpaceXSpaceFeature>();
			}
		}

		protected override List<EFSpaceXSpaceFeature> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFSpaceXSpaceFeature>();
			}
			else
			{
				return this.context.Set<EFSpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSpaceXSpaceFeature>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>a4b0c2d81f1223fa7ff866d65f383458</Hash>
</Codenesium>*/