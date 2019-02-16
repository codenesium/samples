using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IPersonService
	{
		Task<CreateResponse<ApiPersonServerResponseModel>> Create(
			ApiPersonServerRequestModel model);

		Task<UpdateResponse<ApiPersonServerResponseModel>> Update(int personId,
		                                                           ApiPersonServerRequestModel model);

		Task<ActionResponse> Delete(int personId);

		Task<ApiPersonServerResponseModel> Get(int personId);

		Task<List<ApiPersonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiColumnSameAsFKTableServerResponseModel>> ColumnSameAsFKTablesByPerson(int person, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiColumnSameAsFKTableServerResponseModel>> ColumnSameAsFKTablesByPersonId(int personId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1f93ce59973a477e17614e8e5c489d53</Hash>
</Codenesium>*/