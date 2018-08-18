using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLScrapReasonMapper
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
    <Hash>4c054ba3de8cb1c4608c1e5eb25c3222</Hash>
</Codenesium>*/