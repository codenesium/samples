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
			ApiStudentRequestModel model);

		ApiStudentResponseModel MapBOToModel(
			BOStudent boStudent);

		List<ApiStudentResponseModel> MapBOToModel(
			List<BOStudent> items);
	}
}

/*<Codenesium>
    <Hash>360a9dce34a09a30a6bba413838a6d75</Hash>
</Codenesium>*/