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
    <Hash>8dfcf9b7fd1b25f5947404fc3b6b627e</Hash>
</Codenesium>*/