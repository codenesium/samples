using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IEmployeePayHistoryService
	{
		Task<CreateResponse<ApiEmployeePayHistoryResponseModel>> Create(
			ApiEmployeePayHistoryRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiEmployeePayHistoryRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiEmployeePayHistoryResponseModel> Get(int businessEntityID);

		Task<List<ApiEmployeePayHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d0475eae15909130f1410eeab9b17bef</Hash>
</Codenesium>*/