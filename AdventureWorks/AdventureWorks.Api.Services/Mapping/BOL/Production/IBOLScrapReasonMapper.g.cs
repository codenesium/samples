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
			List<BOScrapReason> bos);
	}
}

/*<Codenesium>
    <Hash>785ec6d3f6c1d2b6a8b246999d4fbb05</Hash>
</Codenesium>*/