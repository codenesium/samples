using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDatabaseLogService
	{
		Task<CreateResponse<ApiDatabaseLogServerResponseModel>> Create(
			ApiDatabaseLogServerRequestModel model);

		Task<UpdateResponse<ApiDatabaseLogServerResponseModel>> Update(int databaseLogID,
		                                                                ApiDatabaseLogServerRequestModel model);

		Task<ActionResponse> Delete(int databaseLogID);

		Task<ApiDatabaseLogServerResponseModel> Get(int databaseLogID);

		Task<List<ApiDatabaseLogServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ade793f63453d6c8877deedabef3cd3d</Hash>
</Codenesium>*/