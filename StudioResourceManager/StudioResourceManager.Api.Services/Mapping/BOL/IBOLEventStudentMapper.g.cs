using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLEventStudentMapper
	{
		BOEventStudent MapModelToBO(
			int id,
			ApiEventStudentRequestModel model);

		ApiEventStudentResponseModel MapBOToModel(
			BOEventStudent boEventStudent);

		List<ApiEventStudentResponseModel> MapBOToModel(
			List<BOEventStudent> items);
	}
}

/*<Codenesium>
    <Hash>c02241131c00911d56cbf5e7d14b93e2</Hash>
</Codenesium>*/