using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>5b34756547fe96bac993811b03bc9cdf</Hash>
</Codenesium>*/