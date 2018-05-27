using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLSalesOrderHeaderMapper
	{
		DTOSalesOrderHeader MapModelToDTO(
			int salesOrderID,
			ApiSalesOrderHeaderRequestModel model);

		ApiSalesOrderHeaderResponseModel MapDTOToModel(
			DTOSalesOrderHeader dtoSalesOrderHeader);

		List<ApiSalesOrderHeaderResponseModel> MapDTOToModel(
			List<DTOSalesOrderHeader> dtos);
	}
}

/*<Codenesium>
    <Hash>eec8c5ef1a949e2436862527d026225d</Hash>
</Codenesium>*/