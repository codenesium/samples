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
	public partial class EventStudentRepository : AbstractEventStudentRepository, IEventStudentRepository
	{
		public EventStudentRepository(
			ILogger<EventStudentRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0978401284171fcf0e8f4743dba2e215</Hash>
</Codenesium>*/