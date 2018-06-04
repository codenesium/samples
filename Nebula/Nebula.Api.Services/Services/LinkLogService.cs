using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public class LinkLogService: AbstractLinkLogService, ILinkLogService
	{
		public LinkLogService(
			ILogger<LinkLogRepository> logger,
			ILinkLogRepository linkLogRepository,
			IApiLinkLogRequestModelValidator linkLogModelValidator,
			IBOLLinkLogMapper BOLlinkLogMapper,
			IDALLinkLogMapper DALlinkLogMapper)
			: base(logger, linkLogRepository,
			       linkLogModelValidator,
			       BOLlinkLogMapper,
			       DALlinkLogMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>80a468debcf3db6f0ab110baf7530d99</Hash>
</Codenesium>*/