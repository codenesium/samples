using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALStudioMapper
	{
		Studio MapModelToEntity(
			int id,
			ApiStudioServerRequestModel model);

		ApiStudioServerResponseModel MapEntityToModel(
			Studio item);

		List<ApiStudioServerResponseModel> MapEntityToModel(
			List<Studio> items);
	}
}

/*<Codenesium>
    <Hash>d0b000552003d6879652e66fef371977</Hash>
</Codenesium>*/