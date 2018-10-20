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
	}
}

/*<Codenesium>
    <Hash>45ca2d94762bf064d81b31fb0acf6321</Hash>
</Codenesium>*/