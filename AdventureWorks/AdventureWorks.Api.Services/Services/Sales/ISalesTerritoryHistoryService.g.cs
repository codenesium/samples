using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ISalesTerritoryHistoryService
	{
		Task<CreateResponse<ApiSalesTerritoryHistoryResponseModel>> Create(
			ApiSalesTerritoryHistoryRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiSalesTerritoryHistoryRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiSalesTerritoryHistoryResponseModel> Get(int businessEntityID);

		Task<List<ApiSalesTerritoryHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fd37b527953a7cec46a5e323f63942f8</Hash>
</Codenesium>*/