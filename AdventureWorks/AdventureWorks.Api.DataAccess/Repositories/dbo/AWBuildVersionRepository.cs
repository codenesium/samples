using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class AWBuildVersionRepository : AbstractAWBuildVersionRepository, IAWBuildVersionRepository
	{
		public AWBuildVersionRepository(
			ILogger<AWBuildVersionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d631d74c62dbcffc9cbca9ee45d212fc</Hash>
</Codenesium>*/