using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALSpaceMapper
	{
		Space MapModelToEntity(
			int id,
			ApiSpaceServerRequestModel model);

		ApiSpaceServerResponseModel MapEntityToModel(
			Space item);

		List<ApiSpaceServerResponseModel> MapEntityToModel(
			List<Space> items);
	}
}

/*<Codenesium>
    <Hash>25952a71c25b211d2db26569d74db52c</Hash>
</Codenesium>*/