using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>efdc86c4120459750f6382aec2ce8777</Hash>
</Codenesium>*/