using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class VEventService : AbstractVEventService, IVEventService
	{
		public VEventService(
			ILogger<IVEventRepository> logger,
			IVEventRepository vEventRepository,
			IApiVEventRequestModelValidator vEventModelValidator,
			IBOLVEventMapper bolvEventMapper,
			IDALVEventMapper dalvEventMapper)
			: base(logger,
			       vEventRepository,
			       vEventModelValidator,
			       bolvEventMapper,
			       dalvEventMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6eac8934f1377d76030b1af8c496e9cc</Hash>
</Codenesium>*/