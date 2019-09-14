using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace SecureVideoCRMNS.Api.Services
{
	public partial interface IDALVideoMapper
	{
		Video MapModelToEntity(
			int id,
			ApiVideoServerRequestModel model);

		ApiVideoServerResponseModel MapEntityToModel(
			Video item);

		List<ApiVideoServerResponseModel> MapEntityToModel(
			List<Video> items);
	}
}

/*<Codenesium>
    <Hash>bc11ad46d837ba8c1b945a36e006647f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/