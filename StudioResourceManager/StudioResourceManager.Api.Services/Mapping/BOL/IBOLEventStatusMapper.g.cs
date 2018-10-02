using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLEventStatusMapper
	{
		BOEventStatus MapModelToBO(
			int id,
			ApiEventStatusRequestModel model);

		ApiEventStatusResponseModel MapBOToModel(
			BOEventStatus boEventStatus);

		List<ApiEventStatusResponseModel> MapBOToModel(
			List<BOEventStatus> items);
	}
}

/*<Codenesium>
    <Hash>af67a90cd0e7123b432b5e3ae79ee949</Hash>
</Codenesium>*/