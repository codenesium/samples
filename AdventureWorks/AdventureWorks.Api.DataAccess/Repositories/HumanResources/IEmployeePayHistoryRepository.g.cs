using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeePayHistoryRepository
	{
		POCOEmployeePayHistory Create(ApiEmployeePayHistoryModel model);

		void Update(int businessEntityID,
		            ApiEmployeePayHistoryModel model);

		void Delete(int businessEntityID);

		POCOEmployeePayHistory Get(int businessEntityID);

		List<POCOEmployeePayHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e0debf0746f3fbc6b1374fd4b246b2d7</Hash>
</Codenesium>*/