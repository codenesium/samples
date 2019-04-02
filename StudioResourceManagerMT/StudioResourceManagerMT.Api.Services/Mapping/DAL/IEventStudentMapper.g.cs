using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALEventStudentMapper
	{
		EventStudent MapModelToEntity(
			int id,
			ApiEventStudentServerRequestModel model);

		ApiEventStudentServerResponseModel MapEntityToModel(
			EventStudent item);

		List<ApiEventStudentServerResponseModel> MapEntityToModel(
			List<EventStudent> items);
	}
}

/*<Codenesium>
    <Hash>eca8ac8b91aaf1ff3095a75765517d94</Hash>
</Codenesium>*/