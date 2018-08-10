using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial class DestinationRepository : AbstractDestinationRepository, IDestinationRepository
	{
		public DestinationRepository(
			ILogger<DestinationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bb0d0947980149f04549f7c7cfd17d19</Hash>
</Codenesium>*/