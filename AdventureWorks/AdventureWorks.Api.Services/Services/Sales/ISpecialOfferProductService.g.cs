using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface ISpecialOfferProductService
	{
		Task<CreateResponse<ApiSpecialOfferProductResponseModel>> Create(
			ApiSpecialOfferProductRequestModel model);

		Task<UpdateResponse<ApiSpecialOfferProductResponseModel>> Update(int specialOfferID,
		                                                                  ApiSpecialOfferProductRequestModel model);

		Task<ActionResponse> Delete(int specialOfferID);

		Task<ApiSpecialOfferProductResponseModel> Get(int specialOfferID);

		Task<List<ApiSpecialOfferProductResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpecialOfferProductResponseModel>> ByProductID(int productID);

		Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetails(int specialOfferID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d9503911436069f7edcebc989d22b504</Hash>
</Codenesium>*/