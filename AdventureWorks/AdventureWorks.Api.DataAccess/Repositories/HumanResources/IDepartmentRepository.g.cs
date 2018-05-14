using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDepartmentRepository
	{
		POCODepartment Create(ApiDepartmentModel model);

		void Update(short departmentID,
		            ApiDepartmentModel model);

		void Delete(short departmentID);

		POCODepartment Get(short departmentID);

		List<POCODepartment> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCODepartment GetName(string name);
	}
}

/*<Codenesium>
    <Hash>093b15e2572c2a2fa91bed0f4257df35</Hash>
</Codenesium>*/