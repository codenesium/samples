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
    <Hash>1a7819830f7d011e393ccfdbf4dc614a</Hash>
</Codenesium>*/