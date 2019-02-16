using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALScrapReasonMapper
	{
		ScrapReason MapModelToBO(
			short scrapReasonID,
			ApiScrapReasonServerRequestModel model);

		ApiScrapReasonServerResponseModel MapBOToModel(
			ScrapReason item);

		List<ApiScrapReasonServerResponseModel> MapBOToModel(
			List<ScrapReason> items);
	}
}

/*<Codenesium>
    <Hash>783d963cf70e2710659b991c20f6497c</Hash>
</Codenesium>*/