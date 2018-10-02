using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLMessengerMapper
	{
		BOMessenger MapModelToBO(
			int id,
			ApiMessengerRequestModel model);

		ApiMessengerResponseModel MapBOToModel(
			BOMessenger boMessenger);

		List<ApiMessengerResponseModel> MapBOToModel(
			List<BOMessenger> items);
	}
}

/*<Codenesium>
    <Hash>1a33316a1ba309897ffd70792402dc68</Hash>
</Codenesium>*/