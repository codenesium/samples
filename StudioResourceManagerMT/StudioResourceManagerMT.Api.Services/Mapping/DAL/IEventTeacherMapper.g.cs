using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALEventTeacherMapper
	{
		EventTeacher MapModelToEntity(
			int eventId,
			ApiEventTeacherServerRequestModel model);

		ApiEventTeacherServerResponseModel MapEntityToModel(
			EventTeacher item);

		List<ApiEventTeacherServerResponseModel> MapEntityToModel(
			List<EventTeacher> items);
	}
}

/*<Codenesium>
    <Hash>ddae7f99bf5ee0cbc4a5306d49e33ac0</Hash>
</Codenesium>*/