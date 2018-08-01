using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeDepartmentHistoryRepository
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
    <Hash>d2d2ded0e6f9d57c2c4b6fb030da9455</Hash>
</Codenesium>*/