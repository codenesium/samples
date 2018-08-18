using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLSalesPersonQuotaHistoryMapper
	{
		BOSalesPersonQuotaHistory MapModelToBO(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryRequestModel model);

		ApiSalesPersonQuotaHistoryResponseModel MapBOToModel(
			BOSalesPersonQuotaHistory boSalesPersonQuotaHistory);

		List<ApiSalesPersonQuotaHistoryResponseModel> MapBOToModel(
			List<BOSalesPersonQuotaHistory> items);
	}
}

/*<Codenesium>
    <Hash>412bec831db564b61d2d60e7185e593d</Hash>
</Codenesium>*/