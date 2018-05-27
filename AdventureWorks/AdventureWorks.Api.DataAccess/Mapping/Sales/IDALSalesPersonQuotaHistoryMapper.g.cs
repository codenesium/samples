using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALSalesPersonQuotaHistoryMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOSalesPersonQuotaHistory dto,
			SalesPersonQuotaHistory efSalesPersonQuotaHistory);

		DTOSalesPersonQuotaHistory MapEFToDTO(
			SalesPersonQuotaHistory efSalesPersonQuotaHistory);
	}
}

/*<Codenesium>
    <Hash>2573999d052f7a84653be15cb7805b30</Hash>
</Codenesium>*/