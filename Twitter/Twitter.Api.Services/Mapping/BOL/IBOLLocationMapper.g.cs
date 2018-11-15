using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLLocationMapper
	{
		BOLocation MapModelToBO(
			int locationId,
			ApiLocationServerRequestModel model);

		ApiLocationServerResponseModel MapBOToModel(
			BOLocation boLocation);

		List<ApiLocationServerResponseModel> MapBOToModel(
			List<BOLocation> items);
	}
}

/*<Codenesium>
    <Hash>62eec4de6c71c166131c3a9e8c574216</Hash>
</Codenesium>*/