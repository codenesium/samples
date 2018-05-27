using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLocation
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
    <Hash>0cb3b3a0a96f44e574ab0889fe21879d</Hash>
</Codenesium>*/