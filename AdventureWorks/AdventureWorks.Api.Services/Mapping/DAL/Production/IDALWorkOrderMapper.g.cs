using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALWorkOrderMapper
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
    <Hash>e742686b8e63578099d27854d99d4209</Hash>
</Codenesium>*/