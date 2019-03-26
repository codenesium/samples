using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALAWBuildVersionMapper
	{
		AWBuildVersion MapModelToEntity(
			int systemInformationID,
			ApiAWBuildVersionServerRequestModel model);

		ApiAWBuildVersionServerResponseModel MapEntityToModel(
			AWBuildVersion item);

		List<ApiAWBuildVersionServerResponseModel> MapEntityToModel(
			List<AWBuildVersion> items);
	}
}

/*<Codenesium>
    <Hash>c147f0d1dcdaf3014dcd7839a804323a</Hash>
</Codenesium>*/