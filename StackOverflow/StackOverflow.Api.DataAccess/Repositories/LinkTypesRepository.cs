using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>3112045b7e1081eda3cdf4bc44d25b7d</Hash>
</Codenesium>*/