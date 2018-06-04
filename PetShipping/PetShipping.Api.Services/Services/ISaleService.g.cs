using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
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
    <Hash>c8fe700dee27da79f9932a9430b37b55</Hash>
</Codenesium>*/