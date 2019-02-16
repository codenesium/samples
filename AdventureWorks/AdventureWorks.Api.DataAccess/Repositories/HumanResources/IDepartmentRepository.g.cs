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

		Task<List<Department>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Department> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>e495c0b11493c70654449b393b5f35f4</Hash>
</Codenesium>*/