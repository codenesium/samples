using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IBOLEventMapper
	{
		BOEvent MapModelToBO(
			int id,
			ApiEventServerRequestModel model);

		ApiEventServerResponseModel MapBOToModel(
			BOEvent boEvent);

		List<ApiEventServerResponseModel> MapBOToModel(
			List<BOEvent> items);
	}
}

/*<Codenesium>
    <Hash>7cac6a42ca0cb980b2b6cdc16a7eed89</Hash>
</Codenesium>*/