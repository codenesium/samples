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
    <Hash>a48fb3c016ea09c367cf99f4a5aa4caf</Hash>
</Codenesium>*/