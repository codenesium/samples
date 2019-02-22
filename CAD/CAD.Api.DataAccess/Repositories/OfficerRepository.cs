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
	public partial class OfficerRepository : AbstractOfficerRepository, IOfficerRepository
	{
		public OfficerRepository(
			ILogger<OfficerRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>42827ae334fc327e3c32e8db80d1f887</Hash>
</Codenesium>*/