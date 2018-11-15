using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISpecialOfferService
	{
		Task<CreateResponse<ApiSpecialOfferServerResponseModel>> Create(
			ApiSpecialOfferServerRequestModel model);

		Task<UpdateResponse<ApiSpecialOfferServerResponseModel>> Update(int specialOfferID,
		                                                                 ApiSpecialOfferServerRequestModel model);

		Task<ActionResponse> Delete(int specialOfferID);

		Task<ApiSpecialOfferServerResponseModel> Get(int specialOfferID);

		Task<List<ApiSpecialOfferServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiSpecialOfferServerResponseModel> ByRowguid(Guid rowguid);
	}
}

/*<Codenesium>
    <Hash>d097743784ea3ab670f2f9a3afd0f2ac</Hash>
</Codenesium>*/