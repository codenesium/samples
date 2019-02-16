using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDepartmentService
	{
		Task<CreateResponse<ApiDepartmentServerResponseModel>> Create(
			ApiDepartmentServerRequestModel model);

		Task<UpdateResponse<ApiDepartmentServerResponseModel>> Update(short departmentID,
		                                                               ApiDepartmentServerRequestModel model);

		Task<ActionResponse> Delete(short departmentID);

		Task<ApiDepartmentServerResponseModel> Get(short departmentID);

		Task<List<ApiDepartmentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiDepartmentServerResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>15a09c30fa6e4f194efbe8e43e3f4422</Hash>
</Codenesium>*/