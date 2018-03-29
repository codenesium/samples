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
	public class PersonCreditCardRepository: AbstractPersonCreditCardRepository, IPersonCreditCardRepository
	{
		public PersonCreditCardRepository(ILogger<PersonCreditCardRepository> logger,
		                                  ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFPersonCreditCard> SearchLinqEF(Expression<Func<EFPersonCreditCard, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPersonCreditCard>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFPersonCreditCard>();
			}
			else
			{
				return this._context.Set<EFPersonCreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPersonCreditCard>();
			}
		}

		protected override List<EFPersonCreditCard> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPersonCreditCard>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFPersonCreditCard>();
			}
			else
			{
				return this._context.Set<EFPersonCreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPersonCreditCard>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>688685ab20bdd1c6099635005c48430e</Hash>
</Codenesium>*/