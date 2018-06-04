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
	public class LinkStatusService: AbstractLinkStatusService, ILinkStatusService
	{
		public LinkStatusService(
			ILogger<LinkStatusRepository> logger,
			ILinkStatusRepository linkStatusRepository,
			IApiLinkStatusRequestModelValidator linkStatusModelValidator,
			IBOLLinkStatusMapper BOLlinkStatusMapper,
			IDALLinkStatusMapper DALlinkStatusMapper)
			: base(logger, linkStatusRepository,
			       linkStatusModelValidator,
			       BOLlinkStatusMapper,
			       DALlinkStatusMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>de357b709165497cfde0ec3bb7739dba</Hash>
</Codenesium>*/