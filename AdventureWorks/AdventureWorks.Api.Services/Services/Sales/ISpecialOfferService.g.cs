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

		Task<List<ApiSpecialOfferServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiSpecialOfferServerResponseModel> ByRowguid(Guid rowguid);
	}
}

/*<Codenesium>
    <Hash>5dbada1643f046e6a51b031562422bcc</Hash>
</Codenesium>*/