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
	public class SpaceFeatureRepository: AbstractSpaceFeatureRepository, ISpaceFeatureRepository
	{
		public SpaceFeatureRepository(
			IObjectMapper mapper,
			ILogger<SpaceFeatureRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFSpaceFeature> SearchLinqEF(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSpaceFeature>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFSpaceFeature>();
			}
			else
			{
				return this.context.Set<EFSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSpaceFeature>();
			}
		}

		protected override List<EFSpaceFeature> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSpaceFeature>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFSpaceFeature>();
			}
			else
			{
				return this.context.Set<EFSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSpaceFeature>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e68b3f96b3d537adbc7da2b6647a95b7</Hash>
</Codenesium>*/