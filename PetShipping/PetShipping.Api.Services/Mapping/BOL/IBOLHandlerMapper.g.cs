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
			ApiHandlerRequestModel model);

		ApiHandlerResponseModel MapBOToModel(
			BOHandler boHandler);

		List<ApiHandlerResponseModel> MapBOToModel(
			List<BOHandler> items);
	}
}

/*<Codenesium>
    <Hash>2da984c15a992e358dacc273879a043c</Hash>
</Codenesium>*/