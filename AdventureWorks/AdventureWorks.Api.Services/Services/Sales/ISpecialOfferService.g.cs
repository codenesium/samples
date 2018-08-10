using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISpecialOfferService
	{
		Task<CreateResponse<ApiSpecialOfferResponseModel>> Create(
			ApiSpecialOfferRequestModel model);

		Task<UpdateResponse<ApiSpecialOfferResponseModel>> Update(int specialOfferID,
		                                                           ApiSpecialOfferRequestModel model);

		Task<ActionResponse> Delete(int specialOfferID);

		Task<ApiSpecialOfferResponseModel> Get(int specialOfferID);

		Task<List<ApiSpecialOfferResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpecialOfferProductResponseModel>> SpecialOfferProducts(int specialOfferID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3746be21c0f686f3a0fc6e5d46ecaadf</Hash>
</Codenesium>*/