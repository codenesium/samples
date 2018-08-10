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
    <Hash>f70a13f171b4c4d4fa115b6bca91df27</Hash>
</Codenesium>*/