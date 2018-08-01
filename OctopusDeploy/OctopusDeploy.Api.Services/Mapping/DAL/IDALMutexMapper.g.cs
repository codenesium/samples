using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALMutexMapper
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
    <Hash>e6efaeba546925e1444c193ae76743a7</Hash>
</Codenesium>*/