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
			ApiLocationRequestModel model);

		ApiLocationResponseModel MapBOToModel(
			BOLocation boLocation);

		List<ApiLocationResponseModel> MapBOToModel(
			List<BOLocation> items);
	}
}

/*<Codenesium>
    <Hash>a453e108c20ed7df9903fe7b07f226d1</Hash>
</Codenesium>*/