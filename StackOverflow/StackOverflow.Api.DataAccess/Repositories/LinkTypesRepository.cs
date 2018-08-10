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
    <Hash>985ff24f0857d06e63c192113699d3ff</Hash>
</Codenesium>*/