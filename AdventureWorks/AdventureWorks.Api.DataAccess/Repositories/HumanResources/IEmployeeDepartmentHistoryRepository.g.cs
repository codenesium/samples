using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeDepartmentHistoryRepository
	{
		Task<POCOEmployeeDepartmentHistory> Create(ApiEmployeeDepartmentHistoryModel model);

		Task Update(int businessEntityID,
		            ApiEmployeeDepartmentHistoryModel model);

		Task Delete(int businessEntityID);

		Task<POCOEmployeeDepartmentHistory> Get(int businessEntityID);

		Task<List<POCOEmployeeDepartmentHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOEmployeeDepartmentHistory>> GetDepartmentID(short departmentID);
		Task<List<POCOEmployeeDepartmentHistory>> GetShiftID(int shiftID);
	}
}

/*<Codenesium>
    <Hash>65e8f0c6bd4e49847613ee407fb67d7d</Hash>
</Codenesium>*/