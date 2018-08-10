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
    <Hash>f272a64310a090bbd0359a62c8076af9</Hash>
</Codenesium>*/