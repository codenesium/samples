using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLStudentMapper
	{
		BOStudent MapModelToBO(
			int id,
			ApiStudentServerRequestModel model);

		ApiStudentServerResponseModel MapBOToModel(
			BOStudent boStudent);

		List<ApiStudentServerResponseModel> MapBOToModel(
			List<BOStudent> items);
	}
}

/*<Codenesium>
    <Hash>7408d9d206239aad5de43d8f2620f220</Hash>
</Codenesium>*/