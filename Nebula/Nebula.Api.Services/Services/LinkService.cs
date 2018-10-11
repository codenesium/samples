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
			IDALLinkLogMapper dalLinkLogMapper)
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
    <Hash>36abeeb0f4b5a4f48de0a02b4a50d5b1</Hash>
</Codenesium>*/