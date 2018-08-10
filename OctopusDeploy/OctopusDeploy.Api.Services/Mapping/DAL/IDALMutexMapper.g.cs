using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALMutexMapper
	{
		Mutex MapBOToEF(
			BOMutex bo);

		BOMutex MapEFToBO(
			Mutex efMutex);

		List<BOMutex> MapEFToBO(
			List<Mutex> records);
	}
}

/*<Codenesium>
    <Hash>770c48bac8099dcf9ac230414bbdeef5</Hash>
</Codenesium>*/