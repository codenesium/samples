using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>c7dfa92d4cfd2ef7e55d7fd8a28eb912</Hash>
</Codenesium>*/