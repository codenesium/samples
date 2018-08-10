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

		Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistories(short departmentID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>33d80672e4f1ebee827c8533a54a24d8</Hash>
</Codenesium>*/