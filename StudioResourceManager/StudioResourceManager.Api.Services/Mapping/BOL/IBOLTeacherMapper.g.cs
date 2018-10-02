using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLTeacherMapper
	{
		BOTeacher MapModelToBO(
			int id,
			ApiTeacherRequestModel model);

		ApiTeacherResponseModel MapBOToModel(
			BOTeacher boTeacher);

		List<ApiTeacherResponseModel> MapBOToModel(
			List<BOTeacher> items);
	}
}

/*<Codenesium>
    <Hash>80317e5e8dfef4afdd310ab0c9e7a2dd</Hash>
</Codenesium>*/