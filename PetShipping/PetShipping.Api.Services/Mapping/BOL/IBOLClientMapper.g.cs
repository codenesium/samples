using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>a05eb0cf1d5e9b3f95faa8dfc948a388</Hash>
</Codenesium>*/