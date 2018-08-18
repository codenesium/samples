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
	public partial class AirlineRepository : AbstractAirlineRepository, IAirlineRepository
	{
		public AirlineRepository(
			ILogger<AirlineRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>703c7f662395f4bf02b7c4770280c75f</Hash>
</Codenesium>*/