using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALMessengerMapper
	{
		Messenger MapModelToEntity(
			int id,
			ApiMessengerServerRequestModel model);

		ApiMessengerServerResponseModel MapEntityToModel(
			Messenger item);

		List<ApiMessengerServerResponseModel> MapEntityToModel(
			List<Messenger> items);
	}
}

/*<Codenesium>
    <Hash>91e0f789e5da3e1d5c58908840637a9f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/