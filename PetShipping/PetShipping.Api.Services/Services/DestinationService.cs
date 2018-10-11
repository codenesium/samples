using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial class DestinationService : AbstractDestinationService, IDestinationService
	{
		public DestinationService(
			ILogger<IDestinationRepository> logger,
			IDestinationRepository destinationRepository,
			IApiDestinationRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper boldestinationMapper,
			IDALDestinationMapper daldestinationMapper)
			: base(logger,
			       destinationRepository,
			       destinationModelValidator,
			       boldestinationMapper,
			       daldestinationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f623caf330fb3894fbe00d3db04093d5</Hash>
</Codenesium>*/