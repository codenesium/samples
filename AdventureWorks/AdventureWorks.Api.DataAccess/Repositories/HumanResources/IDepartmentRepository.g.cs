using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDepartmentRepository
	{
		Task<DTODepartment> Create(DTODepartment dto);

		Task Update(short departmentID,
		            DTODepartment dto);

		Task Delete(short departmentID);

		Task<DTODepartment> Get(short departmentID);

		Task<List<DTODepartment>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTODepartment> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>a88fdfbbf8335f7e1e8d1d2b5d2ca31d</Hash>
</Codenesium>*/