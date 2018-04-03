using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CountryRegionRepository: AbstractCountryRegionRepository, ICountryRegionRepository
	{
		public CountryRegionRepository(ILogger<CountryRegionRepository> logger,
		                               ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFCountryRegion> SearchLinqEF(Expression<Func<EFCountryRegion, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFCountryRegion>().Where(predicate).AsQueryable().OrderBy("countryRegionCode ASC").Skip(skip).Take(take).ToList<EFCountryRegion>();
			}
			else
			{
				return this._context.Set<EFCountryRegion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCountryRegion>();
			}
		}

		protected override List<EFCountryRegion> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFCountryRegion>().Where(predicate).AsQueryable().OrderBy("countryRegionCode ASC").Skip(skip).Take(take).ToList<EFCountryRegion>();
			}
			else
			{
				return this._context.Set<EFCountryRegion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCountryRegion>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>94dd3ba7cf32063a64bcef9b2534e563</Hash>
</Codenesium>*/