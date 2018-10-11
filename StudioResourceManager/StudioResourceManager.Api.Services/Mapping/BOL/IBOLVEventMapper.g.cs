using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLVEventMapper
	{
		BOVEvent MapModelToBO(
			int id,
			ApiVEventRequestModel model);

		ApiVEventResponseModel MapBOToModel(
			BOVEvent boVEvent);

		List<ApiVEventResponseModel> MapBOToModel(
			List<BOVEvent> items);
	}
}

/*<Codenesium>
    <Hash>93f68e2ca94aa484ad38611d859b8165</Hash>
</Codenesium>*/