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
    <Hash>218dc307eb10802c8745f4d66273fad9</Hash>
</Codenesium>*/