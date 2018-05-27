using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALWorkOrderMapper
	{
		void MapDTOToEF(
			int workOrderID,
			DTOWorkOrder dto,
			WorkOrder efWorkOrder);

		DTOWorkOrder MapEFToDTO(
			WorkOrder efWorkOrder);
	}
}

/*<Codenesium>
    <Hash>8095b2b13a690fcb42f9dd389629db88</Hash>
</Codenesium>*/