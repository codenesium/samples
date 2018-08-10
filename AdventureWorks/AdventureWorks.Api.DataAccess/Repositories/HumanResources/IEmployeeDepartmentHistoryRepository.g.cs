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

		Task<List<EmployeeDepartmentHistory>> ByDepartmentID(short departmentID);

		Task<List<EmployeeDepartmentHistory>> ByShiftID(int shiftID);
	}
}

/*<Codenesium>
    <Hash>bda48cabb009240069d55ce653a24566</Hash>
</Codenesium>*/