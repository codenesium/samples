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
	public partial class LinkTypeRepository : AbstractLinkTypeRepository, ILinkTypeRepository
	{
		public LinkTypeRepository(
			ILogger<LinkTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>30e691390e73c5b45c1eba1ec1a63c3b</Hash>
</Codenesium>*/