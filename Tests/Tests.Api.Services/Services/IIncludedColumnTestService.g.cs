using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IIncludedColumnTestService
	{
		Task<CreateResponse<ApiIncludedColumnTestServerResponseModel>> Create(
			ApiIncludedColumnTestServerRequestModel model);

		Task<UpdateResponse<ApiIncludedColumnTestServerResponseModel>> Update(int id,
		                                                                       ApiIncludedColumnTestServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiIncludedColumnTestServerResponseModel> Get(int id);

		Task<List<ApiIncludedColumnTestServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>76fbb0b6955b99f826dc58acf9155946</Hash>
</Codenesium>*/