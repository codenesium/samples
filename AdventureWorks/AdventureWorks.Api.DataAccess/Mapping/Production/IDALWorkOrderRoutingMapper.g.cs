using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALWorkOrderRoutingMapper
	{
		void MapDTOToEF(
			int workOrderID,
			DTOWorkOrderRouting dto,
			WorkOrderRouting efWorkOrderRouting);

		DTOWorkOrderRouting MapEFToDTO(
			WorkOrderRouting efWorkOrderRouting);
	}
}

/*<Codenesium>
    <Hash>dbdf4d299769da816d4f8e0c034a904f</Hash>
</Codenesium>*/