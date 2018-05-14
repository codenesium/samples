using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOEmployeeDepartmentHistory
	{
		Task<CreateResponse<POCOEmployeeDepartmentHistory>> Create(
			ApiEmployeeDepartmentHistoryModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiEmployeeDepartmentHistoryModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOEmployeeDepartmentHistory Get(int businessEntityID);

		List<POCOEmployeeDepartmentHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmployeeDepartmentHistory> GetDepartmentID(short departmentID);
		List<POCOEmployeeDepartmentHistory> GetShiftID(int shiftID);
	}
}

/*<Codenesium>
    <Hash>cc9a5879d3ebad4e4f457d7e292ff790</Hash>
</Codenesium>*/