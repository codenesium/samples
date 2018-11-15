using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLFamilyMapper
	{
		BOFamily MapModelToBO(
			int id,
			ApiFamilyServerRequestModel model);

		ApiFamilyServerResponseModel MapBOToModel(
			BOFamily boFamily);

		List<ApiFamilyServerResponseModel> MapBOToModel(
			List<BOFamily> items);
	}
}

/*<Codenesium>
    <Hash>b9fc32741b1dbcbe34b6ec14455ceb28</Hash>
</Codenesium>*/