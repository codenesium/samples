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

		Task<List<ApiDepartmentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiDepartmentServerResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>d720933b2c566d029d6d5491a4d53f87</Hash>
</Codenesium>*/