using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALKeyAllocationMapper
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
    <Hash>c3ac693a960461b317a999b02e55ca05</Hash>
</Codenesium>*/