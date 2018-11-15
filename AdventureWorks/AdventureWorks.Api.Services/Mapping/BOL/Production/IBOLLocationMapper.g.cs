using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLLocationMapper
	{
		BOLocation MapModelToBO(
			short locationID,
			ApiLocationServerRequestModel model);

		ApiLocationServerResponseModel MapBOToModel(
			BOLocation boLocation);

		List<ApiLocationServerResponseModel> MapBOToModel(
			List<BOLocation> items);
	}
}

/*<Codenesium>
    <Hash>7f8098f04f6e779558dd18d3fd4ac542</Hash>
</Codenesium>*/