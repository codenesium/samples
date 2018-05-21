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

		Task<POCODepartment> Get(short departmentID);

		Task<List<POCODepartment>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCODepartment> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>1d4b90d430948ad25d5eabed6c0d5c57</Hash>
</Codenesium>*/