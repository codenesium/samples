using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDatabaseLogService
	{
		Task<CreateResponse<ApiDatabaseLogResponseModel>> Create(
			ApiDatabaseLogRequestModel model);

		Task<UpdateResponse<ApiDatabaseLogResponseModel>> Update(int databaseLogID,
		                                                          ApiDatabaseLogRequestModel model);

		Task<ActionResponse> Delete(int databaseLogID);

		Task<ApiDatabaseLogResponseModel> Get(int databaseLogID);

		Task<List<ApiDatabaseLogResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e93df4a8124f2205297c4e0d831eec9c</Hash>
</Codenesium>*/