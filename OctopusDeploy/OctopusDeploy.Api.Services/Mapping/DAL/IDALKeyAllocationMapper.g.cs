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
    <Hash>7edc5228ebea33f14e9c8aab1fd7fef9</Hash>
</Codenesium>*/