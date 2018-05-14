using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBODepartment
	{
		Task<CreateResponse<POCODepartment>> Create(
			ApiDepartmentModel model);

		Task<ActionResponse> Update(short departmentID,
		                            ApiDepartmentModel model);

		Task<ActionResponse> Delete(short departmentID);

		POCODepartment Get(short departmentID);

		List<POCODepartment> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCODepartment GetName(string name);
	}
}

/*<Codenesium>
    <Hash>224b5e5b6f3ca6bfac0497d7c133e501</Hash>
</Codenesium>*/