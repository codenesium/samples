using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALColumnSameAsFKTableMapper
	{
		ColumnSameAsFKTable MapBOToEF(
			BOColumnSameAsFKTable bo);

		BOColumnSameAsFKTable MapEFToBO(
			ColumnSameAsFKTable efColumnSameAsFKTable);

		List<BOColumnSameAsFKTable> MapEFToBO(
			List<ColumnSameAsFKTable> records);
	}
}

/*<Codenesium>
    <Hash>757c0a22783c3754660192ae8ef90687</Hash>
</Codenesium>*/