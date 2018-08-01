using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductCostHistoryMapper
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
    <Hash>2263f09992a6257adac414d02715deb7</Hash>
</Codenesium>*/