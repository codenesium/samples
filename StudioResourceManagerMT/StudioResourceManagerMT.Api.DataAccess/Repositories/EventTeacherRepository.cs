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
	public partial class EventTeacherRepository : AbstractEventTeacherRepository, IEventTeacherRepository
	{
		public EventTeacherRepository(
			ILogger<EventTeacherRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7014671effff3e11fb1d57f8801f5350</Hash>
</Codenesium>*/