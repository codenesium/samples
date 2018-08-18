using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALWorkerMapper
	{
		Worker MapBOToEF(
			BOWorker bo);

		BOWorker MapEFToBO(
			Worker efWorker);

		List<BOWorker> MapEFToBO(
			List<Worker> records);
	}
}

/*<Codenesium>
    <Hash>126f279d507d9b7f5d5dc61e6958b643</Hash>
</Codenesium>*/