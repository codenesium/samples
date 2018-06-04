using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
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
    <Hash>1df5abb729487bf2b40e4cabb99fff48</Hash>
</Codenesium>*/