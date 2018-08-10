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
    <Hash>17fd99ecc01ca7925a6a625b602442e0</Hash>
</Codenesium>*/