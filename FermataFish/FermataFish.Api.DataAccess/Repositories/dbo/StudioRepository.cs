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
	public class StudioRepository: AbstractStudioRepository, IStudioRepository
	{
		public StudioRepository(
			IObjectMapper mapper,
			ILogger<StudioRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFStudio> SearchLinqEF(Expression<Func<EFStudio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFStudio>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFStudio>();
			}
			else
			{
				return this.context.Set<EFStudio>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStudio>();
			}
		}

		protected override List<EFStudio> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFStudio>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFStudio>();
			}
			else
			{
				return this.context.Set<EFStudio>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStudio>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>44bea4d825c2cea14189dc710db77078</Hash>
</Codenesium>*/