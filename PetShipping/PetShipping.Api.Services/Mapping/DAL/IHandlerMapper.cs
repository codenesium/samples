using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALHandlerMapper
	{
		Handler MapModelToEntity(
			int id,
			ApiHandlerServerRequestModel model);

		ApiHandlerServerResponseModel MapEntityToModel(
			Handler item);

		List<ApiHandlerServerResponseModel> MapEntityToModel(
			List<Handler> items);
	}
}

/*<Codenesium>
    <Hash>55dedbb60b3146c666db071d06e8e6c3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/