using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALMessengerMapper
	{
		Messenger MapBOToEF(
			BOMessenger bo);

		BOMessenger MapEFToBO(
			Messenger efMessenger);

		List<BOMessenger> MapEFToBO(
			List<Messenger> records);
	}
}

/*<Codenesium>
    <Hash>2323128fd9c1cbcc993a9deb74be32f4</Hash>
</Codenesium>*/