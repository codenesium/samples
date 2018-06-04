using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public class LinkStatusRepository: AbstractLinkStatusRepository, ILinkStatusRepository
	{
		public LinkStatusRepository(
			ILogger<LinkStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>f92d0053de9f0269513c467b8db0708e</Hash>
</Codenesium>*/