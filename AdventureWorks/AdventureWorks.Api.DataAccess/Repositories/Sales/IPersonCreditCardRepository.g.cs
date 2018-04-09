using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonCreditCardRepository
	{
		int Create(int creditCardID,
		           DateTime modifiedDate);

		void Update(int businessEntityID, int creditCardID,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOPersonCreditCard GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOPersonCreditCard> GetWhereDirect(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0fbac3f6c07624d59bb6861bab1d8710</Hash>
</Codenesium>*/