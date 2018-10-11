using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLEventStudentMapper
	{
		BOEventStudent MapModelToBO(
			int eventId,
			ApiEventStudentRequestModel model);

		ApiEventStudentResponseModel MapBOToModel(
			BOEventStudent boEventStudent);

		List<ApiEventStudentResponseModel> MapBOToModel(
			List<BOEventStudent> items);
	}
}

/*<Codenesium>
    <Hash>1ae62a3bba365d2868dc1c4fc4feb162</Hash>
</Codenesium>*/