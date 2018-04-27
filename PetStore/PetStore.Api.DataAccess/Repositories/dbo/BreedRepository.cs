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
	public class BreedRepository: AbstractBreedRepository, IBreedRepository
	{
		public BreedRepository(
			IObjectMapper mapper,
			ILogger<BreedRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFBreed> SearchLinqEF(Expression<Func<EFBreed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFBreed>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFBreed>();
			}
			else
			{
				return this.Context.Set<EFBreed>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBreed>();
			}
		}

		protected override List<EFBreed> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFBreed>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFBreed>();
			}
			else
			{
				return this.Context.Set<EFBreed>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBreed>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>702e6e06a1afdef228f9c2a0e8a67bd5</Hash>
</Codenesium>*/