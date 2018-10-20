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

		Task<List<SalesOrderHeader>> SalesOrderHeadersByCreditCardID(int creditCardID, int limit = int.MaxValue, int offset = 0);

		Task<List<CreditCard>> ByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8d7495155111b5f62a16ee04d08527c9</Hash>
</Codenesium>*/