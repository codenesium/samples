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
	public class LinkStatusRepository: AbstractLinkStatusRepository, ILinkStatusRepository
	{
		public LinkStatusRepository(
			IDALLinkStatusMapper mapper,
			ILogger<LinkStatusRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>94be0e2127e86884072db1307135be4a</Hash>
</Codenesium>*/