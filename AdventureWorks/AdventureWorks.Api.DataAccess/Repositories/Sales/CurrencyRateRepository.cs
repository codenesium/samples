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
	public class CurrencyRateRepository: AbstractCurrencyRateRepository, ICurrencyRateRepository
	{
		public CurrencyRateRepository(ILogger<CurrencyRateRepository> logger,
		                              ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFCurrencyRate> SearchLinqEF(Expression<Func<EFCurrencyRate, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFCurrencyRate>().Where(predicate).AsQueryable().OrderBy("currencyRateID ASC").Skip(skip).Take(take).ToList<EFCurrencyRate>();
			}
			else
			{
				return this._context.Set<EFCurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCurrencyRate>();
			}
		}

		protected override List<EFCurrencyRate> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFCurrencyRate>().Where(predicate).AsQueryable().OrderBy("currencyRateID ASC").Skip(skip).Take(take).ToList<EFCurrencyRate>();
			}
			else
			{
				return this._context.Set<EFCurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCurrencyRate>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>af70dd62b54daf66dd4fe721222995be</Hash>
</Codenesium>*/