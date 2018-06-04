using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IDepartmentService
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
    <Hash>195856db51dc27ea3f56518e8e78b9e1</Hash>
</Codenesium>*/