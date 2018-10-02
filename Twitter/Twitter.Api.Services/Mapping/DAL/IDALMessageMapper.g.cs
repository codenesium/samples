using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALMessageMapper
	{
		Message MapBOToEF(
			BOMessage bo);

		BOMessage MapEFToBO(
			Message efMessage);

		List<BOMessage> MapEFToBO(
			List<Message> records);
	}
}

/*<Codenesium>
    <Hash>499cb799fab411658b01053027361086</Hash>
</Codenesium>*/