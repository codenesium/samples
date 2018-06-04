using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALWorkOrderRoutingMapper
	{
		WorkOrderRouting MapBOToEF(
			BOWorkOrderRouting bo);

		BOWorkOrderRouting MapEFToBO(
			WorkOrderRouting efWorkOrderRouting);

		List<BOWorkOrderRouting> MapEFToBO(
			List<WorkOrderRouting> records);
	}
}

/*<Codenesium>
    <Hash>b63ddaf756b9d8d1c8e96656860afb66</Hash>
</Codenesium>*/