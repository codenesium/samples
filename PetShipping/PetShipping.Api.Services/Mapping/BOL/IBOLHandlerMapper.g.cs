using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>484b425c6236dbdd263bca28f581e046</Hash>
</Codenesium>*/