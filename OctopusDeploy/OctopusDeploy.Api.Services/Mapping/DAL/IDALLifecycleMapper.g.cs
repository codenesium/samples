using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALLifecycleMapper
	{
		Lifecycle MapBOToEF(
			BOLifecycle bo);

		BOLifecycle MapEFToBO(
			Lifecycle efLifecycle);

		List<BOLifecycle> MapEFToBO(
			List<Lifecycle> records);
	}
}

/*<Codenesium>
    <Hash>3915cde9543c747190efe1ab7649e096</Hash>
</Codenesium>*/