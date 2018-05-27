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
		Task<CreateResponse<ApiDepartmentResponseModel>> Create(
			ApiDepartmentRequestModel model);

		Task<ActionResponse> Update(short departmentID,
		                            ApiDepartmentRequestModel model);

		Task<ActionResponse> Delete(short departmentID);

		Task<ApiDepartmentResponseModel> Get(short departmentID);

		Task<List<ApiDepartmentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiDepartmentResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>c15c74b78440e6a491c79a340a2325a9</Hash>
</Codenesium>*/