using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALKeyAllocationMapper
	{
		KeyAllocation MapBOToEF(
			BOKeyAllocation bo);

		BOKeyAllocation MapEFToBO(
			KeyAllocation efKeyAllocation);

		List<BOKeyAllocation> MapEFToBO(
			List<KeyAllocation> records);
	}
}

/*<Codenesium>
    <Hash>cb7696d60b111ed5172aa72992a4af16</Hash>
</Codenesium>*/