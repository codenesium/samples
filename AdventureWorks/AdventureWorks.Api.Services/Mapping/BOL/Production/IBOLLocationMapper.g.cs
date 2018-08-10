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
    <Hash>fc26a2bfbdae8f5f3c0ccbabf2feab22</Hash>
</Codenesium>*/