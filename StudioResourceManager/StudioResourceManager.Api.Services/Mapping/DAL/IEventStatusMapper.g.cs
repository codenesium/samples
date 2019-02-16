using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>eb41370c90f9abb71c09e9e933c86554</Hash>
</Codenesium>*/