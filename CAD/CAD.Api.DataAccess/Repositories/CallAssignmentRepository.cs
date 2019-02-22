using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial class CallAssignmentRepository : AbstractCallAssignmentRepository, ICallAssignmentRepository
	{
		public CallAssignmentRepository(
			ILogger<CallAssignmentRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6a100a34eda7513457d446a0e83ae09c</Hash>
</Codenesium>*/