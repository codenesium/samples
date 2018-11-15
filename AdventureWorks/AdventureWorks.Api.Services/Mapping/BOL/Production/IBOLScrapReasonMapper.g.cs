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
			ApiScrapReasonServerRequestModel model);

		ApiScrapReasonServerResponseModel MapBOToModel(
			BOScrapReason boScrapReason);

		List<ApiScrapReasonServerResponseModel> MapBOToModel(
			List<BOScrapReason> items);
	}
}

/*<Codenesium>
    <Hash>dfa06d76b06c94a67324cd7b05f164c1</Hash>
</Codenesium>*/