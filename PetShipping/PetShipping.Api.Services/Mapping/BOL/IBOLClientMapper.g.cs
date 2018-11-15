using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLClientMapper
	{
		BOClient MapModelToBO(
			int id,
			ApiClientServerRequestModel model);

		ApiClientServerResponseModel MapBOToModel(
			BOClient boClient);

		List<ApiClientServerResponseModel> MapBOToModel(
			List<BOClient> items);
	}
}

/*<Codenesium>
    <Hash>af6e6b60403f722f01c786978e44c575</Hash>
</Codenesium>*/