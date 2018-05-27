using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALSalesOrderHeaderMapper
	{
		void MapDTOToEF(
			int salesOrderID,
			DTOSalesOrderHeader dto,
			SalesOrderHeader efSalesOrderHeader);

		DTOSalesOrderHeader MapEFToDTO(
			SalesOrderHeader efSalesOrderHeader);
	}
}

/*<Codenesium>
    <Hash>357bc56ea098ef3d72275d47b295e5e1</Hash>
</Codenesium>*/