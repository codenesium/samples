using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALWorkOrderRoutingMapper
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
    <Hash>a41b6e52d7e30e23f9b70be79745dcf2</Hash>
</Codenesium>*/