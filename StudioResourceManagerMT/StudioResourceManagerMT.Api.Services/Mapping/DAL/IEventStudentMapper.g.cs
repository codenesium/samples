using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALEventStudentMapper
	{
		EventStudent MapModelToEntity(
			int eventId,
			ApiEventStudentServerRequestModel model);

		ApiEventStudentServerResponseModel MapEntityToModel(
			EventStudent item);

		List<ApiEventStudentServerResponseModel> MapEntityToModel(
			List<EventStudent> items);
	}
}

/*<Codenesium>
    <Hash>1a93ac5407a0f6509a36689ffec1cde4</Hash>
</Codenesium>*/