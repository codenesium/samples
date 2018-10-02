using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLEventMapper
	{
		BOEvent MapModelToBO(
			int id,
			ApiEventRequestModel model);

		ApiEventResponseModel MapBOToModel(
			BOEvent boEvent);

		List<ApiEventResponseModel> MapBOToModel(
			List<BOEvent> items);
	}
}

/*<Codenesium>
    <Hash>ff479b87907233c942063fa47e2ca7f0</Hash>
</Codenesium>*/