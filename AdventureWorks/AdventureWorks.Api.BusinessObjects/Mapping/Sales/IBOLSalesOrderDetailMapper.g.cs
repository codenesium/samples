using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLSalesOrderDetailMapper
	{
		DTOSalesOrderDetail MapModelToDTO(
			int salesOrderID,
			ApiSalesOrderDetailRequestModel model);

		ApiSalesOrderDetailResponseModel MapDTOToModel(
			DTOSalesOrderDetail dtoSalesOrderDetail);

		List<ApiSalesOrderDetailResponseModel> MapDTOToModel(
			List<DTOSalesOrderDetail> dtos);
	}
}

/*<Codenesium>
    <Hash>0ac77c78a3576550a700679e065aff74</Hash>
</Codenesium>*/