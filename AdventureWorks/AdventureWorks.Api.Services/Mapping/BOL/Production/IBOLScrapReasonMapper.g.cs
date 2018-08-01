using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLScrapReasonMapper
	{
		BOScrapReason MapModelToBO(
			short scrapReasonID,
			ApiScrapReasonRequestModel model);

		ApiScrapReasonResponseModel MapBOToModel(
			BOScrapReason boScrapReason);

		List<ApiScrapReasonResponseModel> MapBOToModel(
			List<BOScrapReason> items);
	}
}

/*<Codenesium>
    <Hash>edf65f87de4582ef3893d0e8ac1d43c4</Hash>
</Codenesium>*/