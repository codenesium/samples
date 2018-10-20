using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IStoreService
	{
		Task<CreateResponse<ApiStoreResponseModel>> Create(
			ApiStoreRequestModel model);

		Task<UpdateResponse<ApiStoreResponseModel>> Update(int businessEntityID,
		                                                    ApiStoreRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiStoreResponseModel> Get(int businessEntityID);

		Task<List<ApiStoreResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStoreResponseModel>> BySalesPersonID(int? salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStoreResponseModel>> ByDemographic(string demographic, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCustomerResponseModel>> CustomersByStoreID(int storeID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>db30fa61137b8183ec1994fe30c7a03c</Hash>
</Codenesium>*/