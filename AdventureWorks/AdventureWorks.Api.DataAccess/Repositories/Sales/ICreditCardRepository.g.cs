using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICreditCardRepository
	{
		int Create(string cardType,
		           string cardNumber,
		           int expMonth,
		           short expYear,
		           DateTime modifiedDate);

		void Update(int creditCardID, string cardType,
		            string cardNumber,
		            int expMonth,
		            short expYear,
		            DateTime modifiedDate);

		void Delete(int creditCardID);

		Response GetById(int creditCardID);

		POCOCreditCard GetByIdDirect(int creditCardID);

		Response GetWhere(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOCreditCard> GetWhereDirect(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c16ef03dfeacfb64ccf261b75ada80b6</Hash>
</Codenesium>*/