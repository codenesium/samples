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
    <Hash>19a1f8d4ae9a894bf55dcc95258be3ce</Hash>
</Codenesium>*/