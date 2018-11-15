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
	public partial class SpaceRepository : AbstractSpaceRepository, ISpaceRepository
	{
		public SpaceRepository(
			ILogger<SpaceRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4c3523e4179fa14b0c9caefbed63e16d</Hash>
</Codenesium>*/