using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public partial interface IDALDeviceMapper
	{
		Device MapBOToEF(
			BODevice bo);

		BODevice MapEFToBO(
			Device efDevice);

		List<BODevice> MapEFToBO(
			List<Device> records);
	}
}

/*<Codenesium>
    <Hash>94def11e0efa2e5ab656aeaca1a81019</Hash>
</Codenesium>*/