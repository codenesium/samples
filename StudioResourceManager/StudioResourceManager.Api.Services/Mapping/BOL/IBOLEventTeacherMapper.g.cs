using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLEventTeacherMapper
	{
		BOEventTeacher MapModelToBO(
			int eventId,
			ApiEventTeacherRequestModel model);

		ApiEventTeacherResponseModel MapBOToModel(
			BOEventTeacher boEventTeacher);

		List<ApiEventTeacherResponseModel> MapBOToModel(
			List<BOEventTeacher> items);
	}
}

/*<Codenesium>
    <Hash>15c708935852ed47d0a5bc63108e4e22</Hash>
</Codenesium>*/