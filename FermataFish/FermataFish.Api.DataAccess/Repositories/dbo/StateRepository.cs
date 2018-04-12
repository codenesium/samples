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
	public class StateRepository: AbstractStateRepository, IStateRepository
	{
		public StateRepository(
			ILogger<StateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFState> SearchLinqEF(Expression<Func<EFState, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFState>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFState>();
			}
			else
			{
				return this.context.Set<EFState>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFState>();
			}
		}

		protected override List<EFState> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFState>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFState>();
			}
			else
			{
				return this.context.Set<EFState>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFState>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>a2d5dfc5b36eada7c82b8b4de83471e3</Hash>
</Codenesium>*/