using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALEventTeacherMapper
	{
		EventTeacher MapModelToEntity(
			int id,
			ApiEventTeacherServerRequestModel model);

		ApiEventTeacherServerResponseModel MapEntityToModel(
			EventTeacher item);

		List<ApiEventTeacherServerResponseModel> MapEntityToModel(
			List<EventTeacher> items);
	}
}

/*<Codenesium>
    <Hash>22f698d537ca3e8b27f52a1d388d9365</Hash>
</Codenesium>*/