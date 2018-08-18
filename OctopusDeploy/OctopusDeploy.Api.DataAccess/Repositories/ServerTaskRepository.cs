using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class ServerTaskRepository : AbstractServerTaskRepository, IServerTaskRepository
	{
		public ServerTaskRepository(
			ILogger<ServerTaskRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7c48156161c7f9d4cad94d1450e54245</Hash>
</Codenesium>*/