using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALAWBuildVersionMapper
	{
		AWBuildVersion MapModelToBO(
			int systemInformationID,
			ApiAWBuildVersionServerRequestModel model);

		ApiAWBuildVersionServerResponseModel MapBOToModel(
			AWBuildVersion item);

		List<ApiAWBuildVersionServerResponseModel> MapBOToModel(
			List<AWBuildVersion> items);
	}
}

/*<Codenesium>
    <Hash>277d4586ed256b158d94b9591bcdb70e</Hash>
</Codenesium>*/