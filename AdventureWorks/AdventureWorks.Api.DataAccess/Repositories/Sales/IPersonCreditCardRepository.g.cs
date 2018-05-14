using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonCreditCardRepository
	{
		POCOPersonCreditCard Create(ApiPersonCreditCardModel model);

		void Update(int businessEntityID,
		            ApiPersonCreditCardModel model);

		void Delete(int businessEntityID);

		POCOPersonCreditCard Get(int businessEntityID);

		List<POCOPersonCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>168d5fbcdcef8d6f1bfa0f387cdd7d49</Hash>
</Codenesium>*/