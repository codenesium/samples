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
    <Hash>345e0d125085b5ac3f0df9ca504b842d</Hash>
</Codenesium>*/