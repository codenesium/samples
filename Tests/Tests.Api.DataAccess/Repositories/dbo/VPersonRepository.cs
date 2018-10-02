using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial class VPersonRepository : AbstractVPersonRepository, IVPersonRepository
	{
		public VPersonRepository(
			ILogger<VPersonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>65a90d30712d9e40d068c4efeedbb3d2</Hash>
</Codenesium>*/