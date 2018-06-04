using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public interface ISaleService
	{
		Task<CreateResponse<ApiSaleResponseModel>> Create(
			ApiSaleRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSaleRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSaleResponseModel> Get(int id);

		Task<List<ApiSaleResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>096948223cd9c95d2812a8bd66bde830</Hash>
</Codenesium>*/