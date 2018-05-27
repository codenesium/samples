using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALSalesOrderHeaderSalesReasonMapper
	{
		void MapDTOToEF(
			int salesOrderID,
			DTOSalesOrderHeaderSalesReason dto,
			SalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason);

		DTOSalesOrderHeaderSalesReason MapEFToDTO(
			SalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason);
	}
}

/*<Codenesium>
    <Hash>93778f0acb7bd7b9432b7069ebe84ccf</Hash>
</Codenesium>*/