using System;
using System.Linq.Expressions;
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

		void GetById(int creditCardID, Response response);

		void GetWhere(Expression<Func<EFCreditCard, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>961e0c373969f3b82c14761804285902</Hash>
</Codenesium>*/