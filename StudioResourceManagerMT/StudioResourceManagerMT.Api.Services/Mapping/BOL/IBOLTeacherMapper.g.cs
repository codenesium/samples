using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IBOLTeacherMapper
	{
		BOTeacher MapModelToBO(
			int id,
			ApiTeacherServerRequestModel model);

		ApiTeacherServerResponseModel MapBOToModel(
			BOTeacher boTeacher);

		List<ApiTeacherServerResponseModel> MapBOToModel(
			List<BOTeacher> items);
	}
}

/*<Codenesium>
    <Hash>728685668cde52a87e393e6d957885fc</Hash>
</Codenesium>*/