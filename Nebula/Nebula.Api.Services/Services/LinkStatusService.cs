using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class LinkStatusService : AbstractLinkStatusService, ILinkStatusService
	{
		public LinkStatusService(
			ILogger<ILinkStatusRepository> logger,
			ILinkStatusRepository linkStatusRepository,
			IApiLinkStatusRequestModelValidator linkStatusModelValidator,
			IBOLLinkStatusMapper bollinkStatusMapper,
			IDALLinkStatusMapper dallinkStatusMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper
			)
			: base(logger,
			       linkStatusRepository,
			       linkStatusModelValidator,
			       bollinkStatusMapper,
			       dallinkStatusMapper,
			       bolLinkMapper,
			       dalLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7a3ca0a3fa49a919acb15a4a1bbbe5f1</Hash>
</Codenesium>*/