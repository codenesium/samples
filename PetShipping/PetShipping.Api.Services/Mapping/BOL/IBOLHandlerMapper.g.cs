using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLHandlerMapper
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
    <Hash>66214ef507b5b39f6b276d84033736d3</Hash>
</Codenesium>*/