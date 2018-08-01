using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>06f885cdc172f20b6ea7fc92f527a370</Hash>
</Codenesium>*/