using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALEventStatusMapper
	{
		EventStatus MapModelToEntity(
			int id,
			ApiEventStatusServerRequestModel model);

		ApiEventStatusServerResponseModel MapEntityToModel(
			EventStatus item);

		List<ApiEventStatusServerResponseModel> MapEntityToModel(
			List<EventStatus> items);
	}
}

/*<Codenesium>
    <Hash>97a136d82f3c883f032f5aa020c9aece</Hash>
</Codenesium>*/