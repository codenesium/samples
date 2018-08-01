using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class DestinationService : AbstractDestinationService, IDestinationService
	{
		public DestinationService(
			ILogger<IDestinationRepository> logger,
			IDestinationRepository destinationRepository,
			IApiDestinationRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper boldestinationMapper,
			IDALDestinationMapper daldestinationMapper,
			IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper
			)
			: base(logger,
			       destinationRepository,
			       destinationModelValidator,
			       boldestinationMapper,
			       daldestinationMapper,
			       bolPipelineStepDestinationMapper,
			       dalPipelineStepDestinationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>87bcbd9699f0332cb4bb2a4f04d0d635</Hash>
</Codenesium>*/