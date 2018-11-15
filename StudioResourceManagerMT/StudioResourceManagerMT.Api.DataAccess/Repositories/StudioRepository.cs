using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial class StudioRepository : AbstractStudioRepository, IStudioRepository
	{
		public StudioRepository(
			ILogger<StudioRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8e99c37066f6a917671c70f960c41e18</Hash>
</Codenesium>*/