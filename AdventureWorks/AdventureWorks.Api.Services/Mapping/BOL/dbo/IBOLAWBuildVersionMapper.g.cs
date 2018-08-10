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
			ApiAWBuildVersionRequestModel model);

		ApiAWBuildVersionResponseModel MapBOToModel(
			BOAWBuildVersion boAWBuildVersion);

		List<ApiAWBuildVersionResponseModel> MapBOToModel(
			List<BOAWBuildVersion> items);
	}
}

/*<Codenesium>
    <Hash>02444adb0093ccb5e35fc55bf403f45e</Hash>
</Codenesium>*/