using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICreditCardRepository
	{
		POCOCreditCard Create(ApiCreditCardModel model);

		void Update(int creditCardID,
		            ApiCreditCardModel model);

		void Delete(int creditCardID);

		POCOCreditCard Get(int creditCardID);

		List<POCOCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOCreditCard GetCardNumber(string cardNumber);
	}
}

/*<Codenesium>
    <Hash>d81b67376dc2356cc6badf35ec5c009e</Hash>
</Codenesium>*/