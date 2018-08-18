using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IEmployeeDepartmentHistoryRepository
	{
		Task<EmployeeDepartmentHistory> Create(EmployeeDepartmentHistory item);

		Task Update(EmployeeDepartmentHistory item);

		Task Delete(int businessEntityID);

		Task<EmployeeDepartmentHistory> Get(int businessEntityID);

		Task<List<EmployeeDepartmentHistory>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<EmployeeDepartmentHistory>> ByDepartmentID(short departmentID, int limit = int.MaxValue, int offset = 0);

		Task<List<EmployeeDepartmentHistory>> ByShiftID(int shiftID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6026f90fba58dfac9f6d268833797ef0</Hash>
</Codenesium>*/