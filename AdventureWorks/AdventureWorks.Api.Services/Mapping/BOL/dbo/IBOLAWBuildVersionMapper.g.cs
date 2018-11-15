using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLAWBuildVersionMapper
	{
		BOAWBuildVersion MapModelToBO(
			int systemInformationID,
			ApiAWBuildVersionServerRequestModel model);

		ApiAWBuildVersionServerResponseModel MapBOToModel(
			BOAWBuildVersion boAWBuildVersion);

		List<ApiAWBuildVersionServerResponseModel> MapBOToModel(
			List<BOAWBuildVersion> items);
	}
}

/*<Codenesium>
    <Hash>b812ead06f7af353f327ac6bf38a5fde</Hash>
</Codenesium>*/