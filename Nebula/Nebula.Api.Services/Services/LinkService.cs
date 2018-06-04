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
	public class LinkService: AbstractLinkService, ILinkService
	{
		public LinkService(
			ILogger<LinkRepository> logger,
			ILinkRepository linkRepository,
			IApiLinkRequestModelValidator linkModelValidator,
			IBOLLinkMapper BOLlinkMapper,
			IDALLinkMapper DALlinkMapper)
			: base(logger, linkRepository,
			       linkModelValidator,
			       BOLlinkMapper,
			       DALlinkMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>5613c59a0b60ec9a25db589e5c8381e8</Hash>
</Codenesium>*/