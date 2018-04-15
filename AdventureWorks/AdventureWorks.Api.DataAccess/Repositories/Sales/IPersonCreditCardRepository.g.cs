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

		ApiResponse GetById(int businessEntityID);

		POCOPersonCreditCard GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPersonCreditCard> GetWhereDirect(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5c1212f339dbc9d447d10197f3bcce2c</Hash>
</Codenesium>*/