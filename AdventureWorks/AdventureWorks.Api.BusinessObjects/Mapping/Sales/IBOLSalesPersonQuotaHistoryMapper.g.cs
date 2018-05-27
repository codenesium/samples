using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLSalesPersonQuotaHistoryMapper
	{
		DTOSalesPersonQuotaHistory MapModelToDTO(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryRequestModel model);

		ApiSalesPersonQuotaHistoryResponseModel MapDTOToModel(
			DTOSalesPersonQuotaHistory dtoSalesPersonQuotaHistory);

		List<ApiSalesPersonQuotaHistoryResponseModel> MapDTOToModel(
			List<DTOSalesPersonQuotaHistory> dtos);
	}
}

/*<Codenesium>
    <Hash>f6929792e8ef1e4343b0cb1e4ceea7ab</Hash>
</Codenesium>*/