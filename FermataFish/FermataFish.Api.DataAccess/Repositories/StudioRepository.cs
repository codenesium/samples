using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
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
    <Hash>a3538c3c0efa420d96573f680af6f987</Hash>
</Codenesium>*/