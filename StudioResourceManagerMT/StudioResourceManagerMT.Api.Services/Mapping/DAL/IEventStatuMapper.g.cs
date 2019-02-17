using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALEventStatuMapper
	{
		EventStatu MapModelToEntity(
			int id,
			ApiEventStatuServerRequestModel model);

		ApiEventStatuServerResponseModel MapEntityToModel(
			EventStatu item);

		List<ApiEventStatuServerResponseModel> MapEntityToModel(
			List<EventStatu> items);
	}
}

/*<Codenesium>
    <Hash>86ca76c782e86edee6f75fff7b9d9fa1</Hash>
</Codenesium>*/