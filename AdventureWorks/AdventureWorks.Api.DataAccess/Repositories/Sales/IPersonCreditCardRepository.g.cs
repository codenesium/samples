using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonCreditCardRepository
	{
		int Create(PersonCreditCardModel model);

		void Update(int businessEntityID,
		            PersonCreditCardModel model);

		void Delete(int businessEntityID);

		POCOPersonCreditCard Get(int businessEntityID);

		List<POCOPersonCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>90f993a2e2e19da385623d864c477d28</Hash>
</Codenesium>*/