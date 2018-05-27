using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALSalesReasonMapper
	{
		void MapDTOToEF(
			int salesReasonID,
			DTOSalesReason dto,
			SalesReason efSalesReason);

		DTOSalesReason MapEFToDTO(
			SalesReason efSalesReason);
	}
}

/*<Codenesium>
    <Hash>97b9f9d940a265aa93bf05926b955759</Hash>
</Codenesium>*/