using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDepartmentRepository
	{
		short Create(DepartmentModel model);

		void Update(short departmentID,
		            DepartmentModel model);

		void Delete(short departmentID);

		POCODepartment Get(short departmentID);

		List<POCODepartment> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ca7a3480163149b55ac7d38d2a6565d9</Hash>
</Codenesium>*/