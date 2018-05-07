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
		Task<CreateResponse<short>> Create(
			DepartmentModel model);

		Task<ActionResponse> Update(short departmentID,
		                            DepartmentModel model);

		Task<ActionResponse> Delete(short departmentID);

		POCODepartment Get(short departmentID);

		List<POCODepartment> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4f18770d491e174e6cdcba57500bcc8a</Hash>
</Codenesium>*/