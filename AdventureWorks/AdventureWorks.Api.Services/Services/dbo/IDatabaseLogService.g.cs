using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IDatabaseLogService
	{
		Task<CreateResponse<ApiDatabaseLogResponseModel>> Create(
			ApiDatabaseLogRequestModel model);

		Task<ActionResponse> Update(int databaseLogID,
		                            ApiDatabaseLogRequestModel model);

		Task<ActionResponse> Delete(int databaseLogID);

		Task<ApiDatabaseLogResponseModel> Get(int databaseLogID);

		Task<List<ApiDatabaseLogResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>965401c6e42c3fe22c9a5f2da48bcf2a</Hash>
</Codenesium>*/