using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>dda63aebc3495f2409507be8fdb57fbb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/