using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBODatabaseLog
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
    <Hash>1fcb2a0635ab05ac0fde343df3981d09</Hash>
</Codenesium>*/