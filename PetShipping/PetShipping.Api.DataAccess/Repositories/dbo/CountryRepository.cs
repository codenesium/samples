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
	public class CountryRepository: AbstractCountryRepository, ICountryRepository
	{
		public CountryRepository(
			IObjectMapper mapper,
			ILogger<CountryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFCountry> SearchLinqEF(Expression<Func<EFCountry, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFCountry>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFCountry>();
			}
			else
			{
				return this.Context.Set<EFCountry>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCountry>();
			}
		}

		protected override List<EFCountry> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFCountry>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFCountry>();
			}
			else
			{
				return this.Context.Set<EFCountry>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCountry>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>3a4254143c93ee8ba52df12ed56c5b30</Hash>
</Codenesium>*/