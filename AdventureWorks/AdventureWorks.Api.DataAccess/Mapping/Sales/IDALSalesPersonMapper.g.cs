using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALSalesPersonMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOSalesPerson dto,
			SalesPerson efSalesPerson);

		DTOSalesPerson MapEFToDTO(
			SalesPerson efSalesPerson);
	}
}

/*<Codenesium>
    <Hash>cba378f33fb6c7f7653dc87764721b1c</Hash>
</Codenesium>*/