using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IEmployeePayHistoryService
	{
		Task<CreateResponse<ApiEmployeePayHistoryResponseModel>> Create(
			ApiEmployeePayHistoryRequestModel model);

		Task<UpdateResponse<ApiEmployeePayHistoryResponseModel>> Update(int businessEntityID,
		                                                                 ApiEmployeePayHistoryRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiEmployeePayHistoryResponseModel> Get(int businessEntityID);

		Task<List<ApiEmployeePayHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bc5d98dc6bbd4de8925ceb69df491624</Hash>
</Codenesium>*/