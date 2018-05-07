using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICreditCardRepository
	{
		int Create(CreditCardModel model);

		void Update(int creditCardID,
		            CreditCardModel model);

		void Delete(int creditCardID);

		POCOCreditCard Get(int creditCardID);

		List<POCOCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4c54258b4aa7e0a5f379aa78927abe23</Hash>
</Codenesium>*/