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
	public partial class EventStatuRepository : AbstractEventStatuRepository, IEventStatuRepository
	{
		public EventStatuRepository(
			ILogger<EventStatuRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>600564e2a85635dddfd6ae16a02aa954</Hash>
</Codenesium>*/