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
	public partial class OfficerRefCapabilityRepository : AbstractOfficerRefCapabilityRepository, IOfficerRefCapabilityRepository
	{
		public OfficerRefCapabilityRepository(
			ILogger<OfficerRefCapabilityRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f3d6aafa41e8c608026366e12c8a711d</Hash>
</Codenesium>*/