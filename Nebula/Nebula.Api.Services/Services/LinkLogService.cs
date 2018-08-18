using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial class LinkLogService : AbstractLinkLogService, ILinkLogService
	{
		public LinkLogService(
			ILogger<ILinkLogRepository> logger,
			ILinkLogRepository linkLogRepository,
			IApiLinkLogRequestModelValidator linkLogModelValidator,
			IBOLLinkLogMapper bollinkLogMapper,
			IDALLinkLogMapper dallinkLogMapper
			)
			: base(logger,
			       linkLogRepository,
			       linkLogModelValidator,
			       bollinkLogMapper,
			       dallinkLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0e83cf8d8dc6594331db741238b17f06</Hash>
</Codenesium>*/