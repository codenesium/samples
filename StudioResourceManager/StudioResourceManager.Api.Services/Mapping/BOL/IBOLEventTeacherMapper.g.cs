using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLEventTeacherMapper
	{
		BOEventTeacher MapModelToBO(
			int id,
			ApiEventTeacherRequestModel model);

		ApiEventTeacherResponseModel MapBOToModel(
			BOEventTeacher boEventTeacher);

		List<ApiEventTeacherResponseModel> MapBOToModel(
			List<BOEventTeacher> items);
	}
}

/*<Codenesium>
    <Hash>f89da3e774fe12402a6f822a9546ca7b</Hash>
</Codenesium>*/