using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public class SpeciesRepository: AbstractSpeciesRepository, ISpeciesRepository
	{
		public SpeciesRepository(
			IObjectMapper mapper,
			ILogger<SpeciesRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFSpecies> SearchLinqEF(Expression<Func<EFSpecies, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFSpecies>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFSpecies>();
			}
			else
			{
				return this.Context.Set<EFSpecies>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSpecies>();
			}
		}

		protected override List<EFSpecies> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFSpecies>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFSpecies>();
			}
			else
			{
				return this.Context.Set<EFSpecies>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSpecies>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>028adca521eeb82ba0e656ed093ff1a1</Hash>
</Codenesium>*/