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
	}
}

/*<Codenesium>
    <Hash>4a0e6f2d28d5f1df19853882e32a5917</Hash>
</Codenesium>*/