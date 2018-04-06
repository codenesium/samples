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
	public class CreditCardRepository: AbstractCreditCardRepository, ICreditCardRepository
	{
		public CreditCardRepository(ILogger<CreditCardRepository> logger,
		                            ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFCreditCard> SearchLinqEF(Expression<Func<EFCreditCard, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFCreditCard>().Where(predicate).AsQueryable().OrderBy("CreditCardID ASC").Skip(skip).Take(take).ToList<EFCreditCard>();
			}
			else
			{
				return this._context.Set<EFCreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCreditCard>();
			}
		}

		protected override List<EFCreditCard> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFCreditCard>().Where(predicate).AsQueryable().OrderBy("CreditCardID ASC").Skip(skip).Take(take).ToList<EFCreditCard>();
			}
			else
			{
				return this._context.Set<EFCreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCreditCard>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>93fa4ef983c352cab28a146e9dc33d3a</Hash>
</Codenesium>*/