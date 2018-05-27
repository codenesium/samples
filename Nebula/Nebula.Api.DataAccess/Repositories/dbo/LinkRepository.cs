using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class LinkRepository: AbstractLinkRepository, ILinkRepository
	{
		public LinkRepository(
			IDALLinkMapper mapper,
			ILogger<LinkRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c8067a1c6a214f5503966460d8764be2</Hash>
</Codenesium>*/