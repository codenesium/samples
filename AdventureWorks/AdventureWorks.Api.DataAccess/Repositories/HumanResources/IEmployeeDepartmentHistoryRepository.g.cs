using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeDepartmentHistoryRepository
	{
		POCOEmployeeDepartmentHistory Create(ApiEmployeeDepartmentHistoryModel model);

		void Update(int businessEntityID,
		            ApiEmployeeDepartmentHistoryModel model);

		void Delete(int businessEntityID);

		POCOEmployeeDepartmentHistory Get(int businessEntityID);

		List<POCOEmployeeDepartmentHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmployeeDepartmentHistory> GetDepartmentID(short departmentID);
		List<POCOEmployeeDepartmentHistory> GetShiftID(int shiftID);
	}
}

/*<Codenesium>
    <Hash>ee6c526db78c08f570b7d11ecc2e0e32</Hash>
</Codenesium>*/