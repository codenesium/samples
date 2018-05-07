using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeDepartmentHistoryRepository
	{
		int Create(EmployeeDepartmentHistoryModel model);

		void Update(int businessEntityID,
		            EmployeeDepartmentHistoryModel model);

		void Delete(int businessEntityID);

		POCOEmployeeDepartmentHistory Get(int businessEntityID);

		List<POCOEmployeeDepartmentHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>922fbfaaac04f17e40fd0363e16a5886</Hash>
</Codenesium>*/