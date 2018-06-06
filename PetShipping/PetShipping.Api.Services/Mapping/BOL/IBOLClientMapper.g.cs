using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLClientMapper
	{
		BOClient MapModelToBO(
			int id,
			ApiClientRequestModel model);

		ApiClientResponseModel MapBOToModel(
			BOClient boClient);

		List<ApiClientResponseModel> MapBOToModel(
			List<BOClient> items);
	}
}

/*<Codenesium>
    <Hash>55f20fc9a93f5c19f553e9e50d44099e</Hash>
</Codenesium>*/