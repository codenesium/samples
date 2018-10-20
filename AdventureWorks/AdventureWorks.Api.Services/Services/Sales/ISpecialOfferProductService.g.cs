using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISpecialOfferProductService
	{
		Task<CreateResponse<ApiSpecialOfferProductResponseModel>> Create(
			ApiSpecialOfferProductRequestModel model);

		Task<UpdateResponse<ApiSpecialOfferProductResponseModel>> Update(int specialOfferID,
		                                                                  ApiSpecialOfferProductRequestModel model);

		Task<ActionResponse> Delete(int specialOfferID);

		Task<ApiSpecialOfferProductResponseModel> Get(int specialOfferID);

		Task<List<ApiSpecialOfferProductResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>803fc35b01013c6b5752765deb95b55e</Hash>
</Codenesium>*/