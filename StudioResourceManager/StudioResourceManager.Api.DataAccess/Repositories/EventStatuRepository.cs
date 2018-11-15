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
    <Hash>9fcbe6ec98a660f1252d7be08b592432</Hash>
</Codenesium>*/