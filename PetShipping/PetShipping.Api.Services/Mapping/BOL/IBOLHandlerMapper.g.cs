using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLHandlerMapper
	{
		BOHandler MapModelToBO(
			int id,
			ApiHandlerServerRequestModel model);

		ApiHandlerServerResponseModel MapBOToModel(
			BOHandler boHandler);

		List<ApiHandlerServerResponseModel> MapBOToModel(
			List<BOHandler> items);
	}
}

/*<Codenesium>
    <Hash>ebddd040bff2331053312d400fd17349</Hash>
</Codenesium>*/