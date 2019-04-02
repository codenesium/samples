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
    <Hash>d72adaafb62913c506c6f9035becd554</Hash>
</Codenesium>*/