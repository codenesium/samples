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
			ApiTeacherServerRequestModel model);

		ApiTeacherServerResponseModel MapBOToModel(
			BOTeacher boTeacher);

		List<ApiTeacherServerResponseModel> MapBOToModel(
			List<BOTeacher> items);
	}
}

/*<Codenesium>
    <Hash>3a779f94111d5a64279bfea59f97efde</Hash>
</Codenesium>*/