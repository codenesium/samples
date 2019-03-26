using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>00c1c6402bd26fa7d9d1e856a66ebe29</Hash>
</Codenesium>*/