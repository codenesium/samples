using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALScrapReasonMapper
	{
		ScrapReason MapModelToEntity(
			short scrapReasonID,
			ApiScrapReasonServerRequestModel model);

		ApiScrapReasonServerResponseModel MapEntityToModel(
			ScrapReason item);

		List<ApiScrapReasonServerResponseModel> MapEntityToModel(
			List<ScrapReason> items);
	}
}

/*<Codenesium>
    <Hash>23eb28a23b6b2c6e30a32b8e3b4f04df</Hash>
</Codenesium>*/