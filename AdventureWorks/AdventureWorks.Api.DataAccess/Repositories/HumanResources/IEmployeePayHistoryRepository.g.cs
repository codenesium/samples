using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeePayHistoryRepository
	{
		int Create(EmployeePayHistoryModel model);

		void Update(int businessEntityID,
		            EmployeePayHistoryModel model);

		void Delete(int businessEntityID);

		POCOEmployeePayHistory Get(int businessEntityID);

		List<POCOEmployeePayHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2c1f865bccc4bf81d2d92add9d095e8e</Hash>
</Codenesium>*/