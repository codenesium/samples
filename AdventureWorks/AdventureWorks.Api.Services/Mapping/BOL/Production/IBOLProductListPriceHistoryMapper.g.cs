using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductListPriceHistoryMapper
	{
		BOProductListPriceHistory MapModelToBO(
			int productID,
			ApiProductListPriceHistoryRequestModel model);

		ApiProductListPriceHistoryResponseModel MapBOToModel(
			BOProductListPriceHistory boProductListPriceHistory);

		List<ApiProductListPriceHistoryResponseModel> MapBOToModel(
			List<BOProductListPriceHistory> items);
	}
}

/*<Codenesium>
    <Hash>9397e0ced9e747edd51865a38c452fdb</Hash>
</Codenesium>*/