using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>3a16deb939d53573bec5a0b875a80a9b</Hash>
</Codenesium>*/