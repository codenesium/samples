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
	public partial class VEventRepository : AbstractVEventRepository, IVEventRepository
	{
		public VEventRepository(
			ILogger<VEventRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7627cd963562e8b1aeea95578549cd89</Hash>
</Codenesium>*/