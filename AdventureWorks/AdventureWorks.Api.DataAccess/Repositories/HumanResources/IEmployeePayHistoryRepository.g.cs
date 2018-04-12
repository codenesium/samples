using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeePayHistoryRepository
	{
		int Create(
			DateTime rateChangeDate,
			decimal rate,
			int payFrequency,
			DateTime modifiedDate);

		void Update(int businessEntityID,
		            DateTime rateChangeDate,
		            decimal rate,
		            int payFrequency,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOEmployeePayHistory GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFEmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmployeePayHistory> GetWhereDirect(Expression<Func<EFEmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e0b59637cedd59237f1233bcd2e01bff</Hash>
</Codenesium>*/