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
    <Hash>37cf93211eb87071bd10643a1a6dadb1</Hash>
</Codenesium>*/