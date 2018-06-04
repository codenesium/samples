using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class DestinationService: AbstractDestinationService, IDestinationService
	{
		public DestinationService(
			ILogger<DestinationRepository> logger,
			IDestinationRepository destinationRepository,
			IApiDestinationRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper BOLdestinationMapper,
			IDALDestinationMapper DALdestinationMapper)
			: base(logger, destinationRepository,
			       destinationModelValidator,
			       BOLdestinationMapper,
			       DALdestinationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>de144bddaa8f96b404392938a08fc682</Hash>
</Codenesium>*/