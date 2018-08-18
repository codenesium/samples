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
			ApiClientRequestModel model);

		ApiClientResponseModel MapBOToModel(
			BOClient boClient);

		List<ApiClientResponseModel> MapBOToModel(
			List<BOClient> items);
	}
}

/*<Codenesium>
    <Hash>f0b92d845f206cd5c629894b9dd269ed</Hash>
</Codenesium>*/