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
    <Hash>1689cf05d8e85d9edbcfb911eed65790</Hash>
</Codenesium>*/