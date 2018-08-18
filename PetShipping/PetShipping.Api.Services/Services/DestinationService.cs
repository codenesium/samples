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
    <Hash>133752c572331404bb4577aecf963d40</Hash>
</Codenesium>*/