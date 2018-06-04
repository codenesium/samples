using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLSalesPersonQuotaHistoryMapper
	{
		BOSalesPersonQuotaHistory MapModelToBO(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryRequestModel model);

		ApiSalesPersonQuotaHistoryResponseModel MapBOToModel(
			BOSalesPersonQuotaHistory boSalesPersonQuotaHistory);

		List<ApiSalesPersonQuotaHistoryResponseModel> MapBOToModel(
			List<BOSalesPersonQuotaHistory> bos);
	}
}

/*<Codenesium>
    <Hash>50fb09553e1b17ef06faaee75f9ca020</Hash>
</Codenesium>*/