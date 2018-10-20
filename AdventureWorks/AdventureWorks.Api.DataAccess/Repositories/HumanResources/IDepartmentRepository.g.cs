using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IDepartmentRepository
	{
		Task<Department> Create(Department item);

		Task Update(Department item);

		Task Delete(short departmentID);

		Task<Department> Get(short departmentID);

		Task<List<Department>> All(int limit = int.MaxValue, int offset = 0);

		Task<Department> ByName(string name);

		Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistoriesByDepartmentID(short departmentID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>54eb58b870564fd2e2316228b8416835</Hash>
</Codenesium>*/