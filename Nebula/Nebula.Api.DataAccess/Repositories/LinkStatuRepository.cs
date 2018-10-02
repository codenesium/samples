using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial class LinkStatuRepository : AbstractLinkStatuRepository, ILinkStatuRepository
	{
		public LinkStatuRepository(
			ILogger<LinkStatuRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bb1a085ba9ed950d697dc576504b5e4b</Hash>
</Codenesium>*/