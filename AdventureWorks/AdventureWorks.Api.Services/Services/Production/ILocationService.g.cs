using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ILocationService
	{
		Task<CreateResponse<ApiLocationResponseModel>> Create(
			ApiLocationRequestModel model);

		Task<ActionResponse> Update(short locationID,
		                            ApiLocationRequestModel model);

		Task<ActionResponse> Delete(short locationID);

		Task<ApiLocationResponseModel> Get(short locationID);

		Task<List<ApiLocationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiLocationResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>c9572e7efaaf16ac1e9322890bee4122</Hash>
</Codenesium>*/