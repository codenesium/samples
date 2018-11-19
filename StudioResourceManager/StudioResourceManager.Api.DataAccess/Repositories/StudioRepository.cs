using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
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
    <Hash>0e12fc1e8f1e8ece3814688669a97c2c</Hash>
</Codenesium>*/