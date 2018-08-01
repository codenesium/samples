using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IDALTableMapper
	{
		Table MapBOToEF(
			BOTable bo);

		BOTable MapEFToBO(
			Table efTable);

		List<BOTable> MapEFToBO(
			List<Table> records);
	}
}

/*<Codenesium>
    <Hash>22afb8f6712333a57c064548f2a7d359</Hash>
</Codenesium>*/