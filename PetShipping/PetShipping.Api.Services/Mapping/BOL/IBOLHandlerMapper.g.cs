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
			List<BOHandler> bos);
	}
}

/*<Codenesium>
    <Hash>e0b7268dc6feb562df489f104097756d</Hash>
</Codenesium>*/