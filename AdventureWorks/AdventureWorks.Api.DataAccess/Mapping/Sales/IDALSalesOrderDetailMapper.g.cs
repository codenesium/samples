using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALSalesOrderDetailMapper
	{
		void MapDTOToEF(
			int salesOrderID,
			DTOSalesOrderDetail dto,
			SalesOrderDetail efSalesOrderDetail);

		DTOSalesOrderDetail MapEFToDTO(
			SalesOrderDetail efSalesOrderDetail);
	}
}

/*<Codenesium>
    <Hash>22cb66d8d8c25c4fde0d1b4ed78bf9f1</Hash>
</Codenesium>*/