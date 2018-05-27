using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLSalesOrderHeaderSalesReasonMapper
	{
		DTOSalesOrderHeaderSalesReason MapModelToDTO(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonRequestModel model);

		ApiSalesOrderHeaderSalesReasonResponseModel MapDTOToModel(
			DTOSalesOrderHeaderSalesReason dtoSalesOrderHeaderSalesReason);

		List<ApiSalesOrderHeaderSalesReasonResponseModel> MapDTOToModel(
			List<DTOSalesOrderHeaderSalesReason> dtos);
	}
}

/*<Codenesium>
    <Hash>42bc30595d989592f52f513e0510efd4</Hash>
</Codenesium>*/