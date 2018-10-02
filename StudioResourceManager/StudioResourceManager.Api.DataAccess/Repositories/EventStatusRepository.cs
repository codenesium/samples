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
	public partial class EventStatusRepository : AbstractEventStatusRepository, IEventStatusRepository
	{
		public EventStatusRepository(
			ILogger<EventStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6b16b9343f837903661754485588bbb2</Hash>
</Codenesium>*/