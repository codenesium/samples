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
    <Hash>08c6dec3fa0a118b9188b3d7d41ee443</Hash>
</Codenesium>*/