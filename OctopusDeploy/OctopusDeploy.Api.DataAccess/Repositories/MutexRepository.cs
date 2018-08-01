using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class MutexRepository : AbstractMutexRepository, IMutexRepository
	{
		public MutexRepository(
			ILogger<MutexRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>dc5cb1f1ce3ef8f1ba2694c801313fc5</Hash>
</Codenesium>*/