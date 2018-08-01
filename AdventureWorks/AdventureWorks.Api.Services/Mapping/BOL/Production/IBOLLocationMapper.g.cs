using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLLocationMapper
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
    <Hash>5012fb03e5226039f1a7780f09e09a50</Hash>
</Codenesium>*/