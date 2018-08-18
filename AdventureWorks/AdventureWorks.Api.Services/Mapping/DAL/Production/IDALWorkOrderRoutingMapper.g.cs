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
    <Hash>77a7f1ce429626d5609703364fb4420e</Hash>
</Codenesium>*/