using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ICreditCardRepository
	{
		Task<CreditCard> Create(CreditCard item);

		Task Update(CreditCard item);

		Task Delete(int creditCardID);

		Task<CreditCard> Get(int creditCardID);

		Task<List<CreditCard>> All(int limit = int.MaxValue, int offset = 0);

		Task<CreditCard> ByCardNumber(string cardNumber);

		Task<List<PersonCreditCard>> PersonCreditCards(int creditCardID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesOrderHeader>> SalesOrderHeaders(int creditCardID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b841e65c5fbf3a92c3ae17c6ba26ff0d</Hash>
</Codenesium>*/