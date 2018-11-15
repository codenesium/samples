using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>6280910d6e304baa276ec758186368d6</Hash>
</Codenesium>*/