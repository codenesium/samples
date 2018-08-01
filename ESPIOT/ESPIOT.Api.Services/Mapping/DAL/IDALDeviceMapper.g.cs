using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public interface IDALDeviceMapper
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
    <Hash>4fe75110ecc9c8609d0a615d4225c102</Hash>
</Codenesium>*/