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
    <Hash>d185c57521137517cfaafbdf5a0e3d20</Hash>
</Codenesium>*/