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
    <Hash>3e05cab868f7bfa0ad6baffb065f488e</Hash>
</Codenesium>*/