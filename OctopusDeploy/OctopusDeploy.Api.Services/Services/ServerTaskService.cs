using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class ServerTaskService : AbstractServerTaskService, IServerTaskService
	{
		public ServerTaskService(
			ILogger<IServerTaskRepository> logger,
			IServerTaskRepository serverTaskRepository,
			IApiServerTaskRequestModelValidator serverTaskModelValidator,
			IBOLServerTaskMapper bolserverTaskMapper,
			IDALServerTaskMapper dalserverTaskMapper
			)
			: base(logger,
			       serverTaskRepository,
			       serverTaskModelValidator,
			       bolserverTaskMapper,
			       dalserverTaskMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d70077ac9c5ff82d45ba2c7fe87f43da</Hash>
</Codenesium>*/