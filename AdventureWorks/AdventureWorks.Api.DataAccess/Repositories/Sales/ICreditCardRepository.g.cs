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

		ApiResponse GetById(int creditCardID);

		POCOCreditCard GetByIdDirect(int creditCardID);

		ApiResponse GetWhere(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCreditCard> GetWhereDirect(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ab106c2a702824250109b701e8dff354</Hash>
</Codenesium>*/