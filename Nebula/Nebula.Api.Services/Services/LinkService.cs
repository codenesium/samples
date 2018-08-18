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
	public partial class LinkService : AbstractLinkService, ILinkService
	{
		public LinkService(
			ILogger<ILinkRepository> logger,
			ILinkRepository linkRepository,
			IApiLinkRequestModelValidator linkModelValidator,
			IBOLLinkMapper bollinkMapper,
			IDALLinkMapper dallinkMapper,
			IBOLLinkLogMapper bolLinkLogMapper,
			IDALLinkLogMapper dalLinkLogMapper
			)
			: base(logger,
			       linkRepository,
			       linkModelValidator,
			       bollinkMapper,
			       dallinkMapper,
			       bolLinkLogMapper,
			       dalLinkLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>efad368d292ecc958713a0d1ae8f2a15</Hash>
</Codenesium>*/