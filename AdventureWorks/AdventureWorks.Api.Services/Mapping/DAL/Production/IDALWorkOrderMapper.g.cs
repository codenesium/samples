using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALWorkOrderMapper
	{
		WorkOrder MapBOToEF(
			BOWorkOrder bo);

		BOWorkOrder MapEFToBO(
			WorkOrder efWorkOrder);

		List<BOWorkOrder> MapEFToBO(
			List<WorkOrder> records);
	}
}

/*<Codenesium>
    <Hash>07410ff90765075b7bbef1fd91aee7e8</Hash>
</Codenesium>*/