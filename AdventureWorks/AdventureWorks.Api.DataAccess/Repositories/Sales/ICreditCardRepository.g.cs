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

		Task<List<SalesOrderHeader>> SalesOrderHeaders(int creditCardID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>23f021ed7c3515d21f678a3070045dde</Hash>
</Codenesium>*/