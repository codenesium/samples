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
	public class FamilyRepository: AbstractFamilyRepository, IFamilyRepository
	{
		public FamilyRepository(
			IObjectMapper mapper,
			ILogger<FamilyRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFFamily> SearchLinqEF(Expression<Func<EFFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFFamily>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFFamily>();
			}
			else
			{
				return this.context.Set<EFFamily>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFFamily>();
			}
		}

		protected override List<EFFamily> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFFamily>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFFamily>();
			}
			else
			{
				return this.context.Set<EFFamily>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFFamily>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>3a9ea61bb9fd6ba15ae57a1051481edd</Hash>
</Codenesium>*/