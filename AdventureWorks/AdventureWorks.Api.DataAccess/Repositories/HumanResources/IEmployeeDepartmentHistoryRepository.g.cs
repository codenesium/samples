using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeDepartmentHistoryRepository
	{
		Task<EmployeeDepartmentHistory> Create(EmployeeDepartmentHistory item);

		Task Update(EmployeeDepartmentHistory item);

		Task Delete(int businessEntityID);

		Task<EmployeeDepartmentHistory> Get(int businessEntityID);

		Task<List<EmployeeDepartmentHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<EmployeeDepartmentHistory>> GetDepartmentID(short departmentID);
		Task<List<EmployeeDepartmentHistory>> GetShiftID(int shiftID);
	}
}

/*<Codenesium>
    <Hash>c3009d7fd0609664c79bb7f2690285a5</Hash>
</Codenesium>*/