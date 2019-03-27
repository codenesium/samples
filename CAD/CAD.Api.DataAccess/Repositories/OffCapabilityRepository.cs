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
	public partial class OffCapabilityRepository : AbstractOffCapabilityRepository, IOffCapabilityRepository
	{
		public OffCapabilityRepository(
			ILogger<OffCapabilityRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8c65d39edf3908727528a4adce64ff6a</Hash>
</Codenesium>*/