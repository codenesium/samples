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
	public partial class CallTypeRepository : AbstractCallTypeRepository, ICallTypeRepository
	{
		public CallTypeRepository(
			ILogger<CallTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>712acb585fa71c11f05e8d97fee51e05</Hash>
</Codenesium>*/