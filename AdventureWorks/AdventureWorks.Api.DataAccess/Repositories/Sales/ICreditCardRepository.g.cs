using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICreditCardRepository
	{
		Task<POCOCreditCard> Create(ApiCreditCardModel model);

		Task Update(int creditCardID,
		            ApiCreditCardModel model);

		Task Delete(int creditCardID);

		Task<POCOCreditCard> Get(int creditCardID);

		Task<List<POCOCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOCreditCard> GetCardNumber(string cardNumber);
	}
}

/*<Codenesium>
    <Hash>34b078f879b4892c6af8c3b00d227408</Hash>
</Codenesium>*/