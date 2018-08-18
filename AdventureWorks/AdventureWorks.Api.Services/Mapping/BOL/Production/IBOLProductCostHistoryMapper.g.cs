using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductCostHistoryMapper
	{
		BOProductCostHistory MapModelToBO(
			int productID,
			ApiProductCostHistoryRequestModel model);

		ApiProductCostHistoryResponseModel MapBOToModel(
			BOProductCostHistory boProductCostHistory);

		List<ApiProductCostHistoryResponseModel> MapBOToModel(
			List<BOProductCostHistory> items);
	}
}

/*<Codenesium>
    <Hash>6163867fd1721af091448b182e0b3b6f</Hash>
</Codenesium>*/