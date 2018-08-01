using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class KeyAllocationRepository : AbstractKeyAllocationRepository, IKeyAllocationRepository
	{
		public KeyAllocationRepository(
			ILogger<KeyAllocationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9a0bf7701cba4f424b2d24652e14df8c</Hash>
</Codenesium>*/