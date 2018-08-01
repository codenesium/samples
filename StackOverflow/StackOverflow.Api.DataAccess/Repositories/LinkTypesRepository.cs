using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class LinkTypesRepository : AbstractLinkTypesRepository, ILinkTypesRepository
	{
		public LinkTypesRepository(
			ILogger<LinkTypesRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c9aace69a40b26905c11c2df3b9b2d86</Hash>
</Codenesium>*/