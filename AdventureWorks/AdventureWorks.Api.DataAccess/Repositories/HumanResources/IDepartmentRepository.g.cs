using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDepartmentRepository
	{
		Task<POCODepartment> Create(ApiDepartmentModel model);

		Task Update(short departmentID,
		            ApiDepartmentModel model);

		Task Delete(short departmentID);

		Task<POCODepartment> Get(short departmentID);

		Task<List<POCODepartment>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCODepartment> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>947fe9e905ba4f5e81ecf7c2c6705575</Hash>
</Codenesium>*/