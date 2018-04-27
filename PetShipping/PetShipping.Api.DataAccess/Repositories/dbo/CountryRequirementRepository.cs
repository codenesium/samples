using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class CountryRequirementRepository: AbstractCountryRequirementRepository, ICountryRequirementRepository
	{
		public CountryRequirementRepository(
			IObjectMapper mapper,
			ILogger<CountryRequirementRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFCountryRequirement> SearchLinqEF(Expression<Func<EFCountryRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFCountryRequirement>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFCountryRequirement>();
			}
			else
			{
				return this.Context.Set<EFCountryRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCountryRequirement>();
			}
		}

		protected override List<EFCountryRequirement> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFCountryRequirement>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFCountryRequirement>();
			}
			else
			{
				return this.Context.Set<EFCountryRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCountryRequirement>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>9d49fb6c82b2ea5dc6dc69e06aa49849</Hash>
</Codenesium>*/