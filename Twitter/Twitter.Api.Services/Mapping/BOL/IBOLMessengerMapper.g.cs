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
			ApiMessengerServerRequestModel model);

		ApiMessengerServerResponseModel MapBOToModel(
			BOMessenger boMessenger);

		List<ApiMessengerServerResponseModel> MapBOToModel(
			List<BOMessenger> items);
	}
}

/*<Codenesium>
    <Hash>3c4ae085c0292c61aac299d6ffd47cf2</Hash>
</Codenesium>*/